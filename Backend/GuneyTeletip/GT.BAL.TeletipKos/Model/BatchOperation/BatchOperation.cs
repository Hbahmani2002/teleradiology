using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GT.Job.Implementation
{
    public abstract class BatchOperation<TOperationInput, TOperationResult, TOperationOutput> where TOperationResult : OperationResult<TOperationOutput>, new()
    {
        protected OperationSettings Settings { get; }

        public abstract TOperationResult DoSingle(TOperationInput indata);

        public BatchOperation(OperationSettings settings)
        {
            Settings = settings;
        }
        public BatchOperation()
        {
            Settings = new OperationSettings(4, 4);
        }

        public IEnumerable<TOperationResult> DoBatch(IEnumerable<TOperationInput> items, System.Threading.CancellationTokenSource cancelToken = null, BatchProgressItem progressAction = null)
        {
            ConcurrentBag<TOperationResult> result = new ConcurrentBag<TOperationResult>();
            Parallel.ForEach(items, new ParallelOptions() { MaxDegreeOfParallelism = Settings.ParallelTask }, item =>
            {
                if (cancelToken != null)
                {
                    if (cancelToken.IsCancellationRequested)
                    {
                        return;
                    }
                }
                TOperationResult res = null;
                try
                {
                    res = DoSingle(item);
                    result.Add(res);
                }
                catch (System.Exception ex)
                {
                    res = new TOperationResult
                    {
                        IsSuccess = false,
                        StackTrace = ex.ToString()
                    };
                }
                if (progressAction != null)
                {
                    if (res.IsSuccess)
                    {
                        progressAction.IncreaseProgressSuccess();
                    }
                    else
                    {
                        progressAction.IncreaseProgressError();
                    }
                }
            });
            return result;
        }


    }
}
