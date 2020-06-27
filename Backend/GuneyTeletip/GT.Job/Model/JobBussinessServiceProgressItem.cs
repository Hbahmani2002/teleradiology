using GT.DataService.Implementation;
using System;
using System.Diagnostics;
using System.Threading;

namespace GT.Job.Implementation
{
    public class JobBussinessServiceProgressItem : IDisposable
    {
        public long JobID { get; }
        ThrottleTimer ThrottleTimer;
        internal int maxMiliSecond => 2000;
        public JobBussinessServiceProgressItem(long jobID, int success, int error)
        {
            this.JobID = jobID;
            Success = success;
            Error = error;
            ThrottleTimer = new ThrottleTimer(o =>
            {
                DataProgress();
            }, maxMiliSecond);

        }



        private int success;
        private int error;


        public int Success { get => success; set => success = value; }
        public int Error { get => error; set => error = value; }

        public void IncreaseProgressSuccess()
        {
            Interlocked.Increment(ref success);
            UpdateProgress();
        }
        public void IncreaseProgressError()
        {
            Interlocked.Increment(ref error);
            UpdateProgress();
        }

        private void UpdateProgress()
        {
            lock (_syn)
            {
                Debug.WriteLine("SUCCESS" + success);
                ThrottleTimer.Trigger();
            }
        }

        private void DataProgress()
        {
            Debug.WriteLine($"Tasklist Progress JobId:{JobID}");
            var dataService = new JobDataService(null);
            dataService.SaveProgress(JobID, DateTime.Now, Success, Error);
        }
        object _syn = new object();
        public void Dispose()
        {
            lock (_syn)
            {
                if (ThrottleTimer != null)
                {
                    ThrottleTimer.Dispose();
                    ThrottleTimer = null;
                }
            }
        }
    }
}
