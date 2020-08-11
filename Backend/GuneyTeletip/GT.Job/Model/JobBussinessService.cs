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
            public bool IsStarted { get; private set; }
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
            private void StopTask(Task o)
            {
                o.Dispose();
                this.Task = null;
                this.Stop();
            }
            public void Start()
            {
                Stop();
                JobID = GetSavedTaskID();
                ProgressItem = new JobBussinessServiceProgressItem(JobID, 0, 0);
                _cancelTokenSource = new CancellationTokenSource();

                this.Task = Task.Factory.StartNew(() =>
                {
                    Debug.WriteLine($"JobID:{this.JobID} started");
                    _ac(this._cancelTokenSource, this.ProgressItem);
                    Debug.WriteLine($"JobID:{this.JobID} end");
                }, this._cancelTokenSource.Token);
                this.Task.ContinueWith(t =>
                {
                    Debug.WriteLine($"JobID:{this.JobID} exception occured");
                    SaveException(t.Exception);
                    Debug.WriteLine($"JobID:{this.JobID} exception saved to database");
                }, TaskContinuationOptions.OnlyOnFaulted);
                this.Task.ContinueWith(o =>
                {
                    Debug.WriteLine($"JobID:{this.JobID} is stopping");
                    SaveCloseTask(JobID);
                    StopTask(o);
                    Debug.WriteLine($"JobID:{this.JobID} is stoppped");
                });
                this._jobBussinessService.TaskList.TryAdd(this.JobID, this);
                this.IsStarted = true;
            }

            private void SaveCloseTask(long jobID)
            {
                var dataService = new JobDataService(null);
                dataService.UpdateAndClose(jobID, DateTime.Now);
            }
            private long GetSavedTaskID()
            {
                //TODO JobDataService.JopEnumType.Status Check olmamalı
                var dataService = new JobDataService(null);
                return dataService.Save(DateTime.Now, JobDataService.JopEnumType.StatusCheck);
            }
            private void SaveException(Exception t)
            {
                if (t == null)
                {
                    return;
                }
                var ds = new JobDataService(null);
                ds.SaveException(this.JobID, t.ToString());
            }

            public void Dispose()
            {
                if (_jobBussinessService.Remove(this))
                {
                    Debug.WriteLine($"JobID:{this.JobID} removed");
                    this.Task = null;
                    if (this._cancelTokenSource != null)
                    {
                        this._cancelTokenSource.Cancel();
                        this._cancelTokenSource.Dispose();
                    }
                    this.ProgressItem.Dispose();

                }
                Debug.WriteLine($"JobID:{this.JobID} disposed");
                this.IsStarted = false;
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
    }
}
