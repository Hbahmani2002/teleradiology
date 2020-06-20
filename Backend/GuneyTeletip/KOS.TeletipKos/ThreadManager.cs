using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace KOS.TeletipKos
{
    public static class ThreadManager
    {
        static ThreadManager()
        {
            //ThreadPool.SetMaxThreads(10,100)
        }
        public static long PendingWorkItemCount => ThreadPool.PendingWorkItemCount;

        public static Tuple<int, int> MaxThreads
        {
            get
            {
                ThreadPool.GetMaxThreads(out int a1, out int a2);
                var t = new Tuple<int, int>(a1, a2);
                return t;
            }
        }
        public static Tuple<int, int> AvailableThreads
        {
            get
            {

                ThreadPool.GetAvailableThreads(out int a1, out int a2);
                var t = new Tuple<int, int>(a1, a2);
                return t;
            }
        }

        public static bool QueueUserWorkItem(WaitCallback item)
        {
            return ThreadPool.QueueUserWorkItem(item);
        }

    }
}
