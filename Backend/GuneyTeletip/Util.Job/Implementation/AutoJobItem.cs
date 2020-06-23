using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Util.Job.Interface;

namespace Util.Job
{
    public class BackgroundJobItem
    {
        private class AtJobItem : IDisposable
        {
            public Task JobTask { get; set; }
            public CancellationTokenSource CancelToken { get; set; }

            public void Dispose()
            {
                CancelToken.Dispose();
                JobTask.Dispose();
                JobTask = null;
                CancelToken = null;
            }
        }
        private object _sync;

        public TaskStatus? Status => AtItem == null ? (TaskStatus?)null : AtItem.JobTask.Status;

        Action<CancellationTokenSource> _Action;
        public BackgroundJobItem(Action<CancellationTokenSource> action)
        {
            _sync = new object();
            _Action = action;
        }
        private AtJobItem AtItem { get; set; }


        public void Start()
        {
            if (AtItem != null)
            {
                return;
            }
            lock (_sync)
            {
                if (AtItem != null)
                {
                    return;
                }
                AtItem = new AtJobItem();
                AtItem.CancelToken = new CancellationTokenSource();
                AtItem.JobTask = TaskHelper.RegisterNeverEnding(AtItem.CancelToken, o =>
                {
                    _Action(o);
                });
                Debug.WriteLine("Job Created..");
            }
        }
        public void Stop()
        {
            if (AtItem == null)
                return;

            AtItem.CancelToken.Cancel();
            AtItem.JobTask.ContinueWith(o =>
            {
                Debug.WriteLine("Job Out..");
                if (o.Status == TaskStatus.Faulted)
                {
                    Debug.WriteLine(o.Exception.InnerException);
                }

                AtItem.Dispose();
                AtItem = null;
            }).Wait();
            Debug.WriteLine("Job Out order send..");

        }


    }
}


