using GT.DataService.Implementation;
using System;
using System.Diagnostics;
using System.Threading;

namespace GT.Job.Implementation
{
    //TODO DO Inherit from BatchProgessItem
    public class JobBussinessServiceProgressItem : IDisposable
    {
        public long JobID { get; }

        private ThrottleTimer ThrottleTimer;
        internal int maxMiliSecond => 2000;
        public JobBussinessServiceProgressItem(long jobID, int success, int error)
        {
            JobID = jobID;
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
            JobDataService dataService = new JobDataService(null);
            dataService.Save_UpdateProgress(JobID, DateTime.Now, Success, Error);
        }

        private readonly object _syn = new object();
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
