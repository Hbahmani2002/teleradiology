namespace GT.Job.Implementation
{
    public class JobBussinessServiceProgressItem
    {
        public JobBussinessServiceProgressItem(int success, int error)
        {
            Success = success;
            Error = error;
        }

        public int Success { get; set; }
        public int Error { get; set; }
    }
}
