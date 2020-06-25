using GT.BAL.Infinity.DataSynronizer;
using GT.BAL.TeletipKos.Model;
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
using Util.Job;
using Util.Job.Interface;
using Util.Logger;

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
            internal CancellationTokenSource CancelTokenSource { get; }
            internal Task Task { get; set; }
            ThrottleTimer ThrottleTimer;
            internal int maxMiliSecond => 2000;
            public JobBussinessServiceProgressItem ProgressItem
            {
                get => progressItem;
                set
                {
                    ThrottleTimer.Trigger();
                    progressItem = value;
                }
            }

            private JobBussinessServiceProgressItem progressItem;
            private JobBussinessService _jobBussinessService;


            public JobServiceItem(long jobID, JobBussinessService jobBussinessService)
            {
                JobID = jobID;
                _jobBussinessService = jobBussinessService;
                CancelTokenSource = new CancellationTokenSource();
                ThrottleTimer = new ThrottleTimer(o =>
                {
                    if (this.ProgressItem == null)
                        return;
                    _jobBussinessService.DataProgress(jobID, this.ProgressItem);
                }, maxMiliSecond);
            }
            public void Stop()
            {
                _jobBussinessService.Stop(this);
            }

            public void Dispose()
            {
                if (ThrottleTimer.timer == null)
                    return;
                ThrottleTimer.timer.Dispose();
                Task.Dispose();
                //Task.Dispose();
            }
        }

        private ConcurrentDictionary<long, JobServiceItem> TaskList { get; set; }

        public JobBussinessService()
        {
            TaskList = new ConcurrentDictionary<long, JobServiceItem>();
        }
        public JobServiceItem Create(Action<CancellationTokenSource, Action<JobBussinessServiceProgressItem>> ac)
        {
            var jobID = DataCreate();
            var progress = new JobBussinessServiceProgressItem(0, 0);
            var item = new JobServiceItem(jobID, this);
            item.ProgressItem = progress;

            var task = Task.Factory.StartNew(() =>
            {
                Debug.WriteLine($"JobID:{item.JobID} started");
                ac(item.CancelTokenSource, o =>
                {
                    item.ProgressItem = o;
                });
                DataEnd(item.JobID);
                Debug.WriteLine($"JobID:{item.JobID} end");
            }, item.CancelTokenSource.Token);
            item.Task = task;

            task.ContinueWith(o =>
            {
                RemoveJob(item);
                Debug.WriteLine($"JobID:{item.JobID} removed");
            });

            TaskList.TryAdd(jobID, item);
            return item;
        }
        private bool RemoveJob(JobServiceItem item)
        {
            var res = TaskList.Remove(item.JobID, out JobServiceItem itemRemoved);
            if (res)
            {
                itemRemoved.Dispose();
            }
            var t = itemRemoved == null ? (long?)null : itemRemoved.JobID;
            Debug.WriteLine($"Tasklist remove Result:{res} JobId:{t}");
            return res;
        }

        public int Stop(JobServiceItem job)
        {
            var res = TaskList.TryGetValue(job.JobID, out JobServiceItem item);
            var t = item == null ? (long?)null : item.JobID;
            Debug.WriteLine($"Tasklist Stop Result:{res} JobId:{job.JobID}");
            if (!res)
            {
                //JOb Tamamnlanmış olabilir
                return -1;
                //throw new Exception($"JobId:{jobID} Task Zaten Stopped");
            }
            if (res)
            {
                item.CancelTokenSource.Cancel();
            }
            return 1;
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
        private void DataProgress(long jobID, JobBussinessServiceProgressItem d)
        {
            if (d == null)
            {
                return;
            }
            var res = TaskList.TryGetValue(jobID, out JobServiceItem item);
            if (!res)
                return;
            Debug.WriteLine($"Tasklist Progress JobId:{jobID}");
            var dataService = new JobDataService(null);
            dataService.SaveProgress(jobID, DateTime.Now, d.Success, d.Error);
        }
    }
}
