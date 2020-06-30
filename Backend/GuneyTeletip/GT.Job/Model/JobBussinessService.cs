using App.Data.Service;
using GT.BAL.Infinity.DataSynronizer;
using GT.Core.Settings;
using GT.DataService.Implementation;
using GT.DataService.infinity.Implementation;
using GT.Persistance.Domain.Models;
using GT.Repository.Implementation;
using GT.Repository.Models.View;
using GT.SERVICE;
using GT.TeletipKos;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GT.Job.Implementation
{
    //
    //Bitenleri detect
    //Başlat
    //Job Id ile bitir
    //Timer ile progress
    public class JobBussinessService
    {
        public class JobServiceItem : IDisposable
        {
            public long JobID { get; set; }
            CancellationTokenSource _cancelTokenSource;
            internal Task Task { get; set; }

            public JobBussinessServiceProgressItem ProgressItem { get; private set; }

            private JobBussinessServiceProgressItem progressItem;
            private JobBussinessService _jobBussinessService;
            private Action<CancellationTokenSource, JobBussinessServiceProgressItem> _ac;

            public JobServiceItem(JobBussinessService jobBussinessService, Action<CancellationTokenSource, JobBussinessServiceProgressItem> ac)
            {
                _jobBussinessService = jobBussinessService;
                _ac = ac;
            }
            public void Stop()
            {
                Dispose();
            }
            public void Start()
            {
                Stop();
                JobID = _jobBussinessService.DataCreate();
                ProgressItem = new JobBussinessServiceProgressItem(JobID, 0, 0);
                _cancelTokenSource = new CancellationTokenSource();




                this.Task = Task.Factory.StartNew(() =>
                {
                    Debug.WriteLine($"JobID:{this.JobID} started");
                    _ac(this._cancelTokenSource, this.ProgressItem);
                    Debug.WriteLine($"JobID:{this.JobID} end");
                    Debug.WriteLine($"JobID:{this.JobID} removed");
                }, this._cancelTokenSource.Token);
                this.Task.ContinueWith(t =>
                {
                    var ds = new AppLogDataService();
                    ds.Save(AppLogDataService.LogType.BackGroundJobs, t.Exception.ToString());
                },
                        TaskContinuationOptions.OnlyOnFaulted);
                this.Task.ContinueWith(o =>
                {
                    _jobBussinessService.DataEnd(this.JobID);
                    Debug.WriteLine("Task End and trying to stop");
                    o.Dispose();
                    this.Task = null;
                    this.Stop();
                });

                this._jobBussinessService.TaskList.TryAdd(this.JobID, this);

            }





            public void Dispose()
            {
                if (_jobBussinessService.Remove(this))
                {
                    this.Task = null;
                    if (this._cancelTokenSource != null)
                    {
                        this._cancelTokenSource.Cancel();
                        this._cancelTokenSource.Dispose();
                    }
                    this.ProgressItem.Dispose();

                }

                Debug.WriteLine("Dsiposed");
            }
        }

        private ConcurrentDictionary<long, JobServiceItem> TaskList { get; }

        public JobBussinessService()
        {
            TaskList = new ConcurrentDictionary<long, JobServiceItem>();
        }


        public JobServiceItem Create(Action<CancellationTokenSource, JobBussinessServiceProgressItem> jobAction)
        {
            return new JobServiceItem(this, jobAction);
        }

        public bool Remove(JobServiceItem job)
        {
            var res = TaskList.Remove(job.JobID, out JobServiceItem itemRemoved);
            var t = itemRemoved == null ? (long?)null : itemRemoved.JobID;
            Debug.WriteLine($"Tasklist Stop Result:{res} JobId:{job.JobID}");
            return res;
        }
        private void DataEnd(long jobID)
        {
            var dataService = new JobDataService(null);
            dataService.UpdateAndClose(jobID, DateTime.Now);
        }

        private long DataCreate()
        {
            var dataService = new JobDataService(null);
            return dataService.Save(DateTime.Now, JobDataService.JopEnumType.StatusCheck);
        }

    }
}
