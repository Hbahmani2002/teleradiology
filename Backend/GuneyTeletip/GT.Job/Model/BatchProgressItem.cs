using System.Threading;

namespace GT.Job.Implementation
{
    public abstract class BatchProgressItem
    {
        private readonly object _syn = new object();
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
        public abstract void UpdateProgress();
    }
}
