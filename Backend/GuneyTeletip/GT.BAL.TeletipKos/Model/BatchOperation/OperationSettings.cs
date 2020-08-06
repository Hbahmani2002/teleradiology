namespace GT.Job.Implementation
{
    public class OperationSettings
    {
        public int ItemPerJob { get; set; }
        public int ParallelTask { get; set; }

        public OperationSettings(int itemPerJob, int parallelTask)
        {
            ItemPerJob = itemPerJob;
            ParallelTask = parallelTask;

        }
    }
}
