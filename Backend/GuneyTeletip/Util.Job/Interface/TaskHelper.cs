using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Util.Job.Interface
{

    public class TaskHelper
    {
        public static Task RegisterNeverEnding(CancellationTokenSource tokenSource, Action<CancellationTokenSource> action)
        {
            var task = Task.Run(() =>  // <- marked async
            {
                while (true)
                {
                    action(tokenSource);
                    if (tokenSource.IsCancellationRequested)
                        return;                    
                }
            }, tokenSource.Token);
            return task;
        }

    }
}
