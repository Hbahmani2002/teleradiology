namespace GT.Job.Implementation
{
    public class OperationResult<T> : IOperationResult
    {
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
        public string StackTrace { get; set; }
    }
}
