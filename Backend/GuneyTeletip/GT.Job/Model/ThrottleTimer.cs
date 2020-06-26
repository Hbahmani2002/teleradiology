using System;
using System.Diagnostics;
using System.Threading;

namespace GT.Job.Implementation
{
    public class ThrottleTimer : IDisposable
    {
        Timer timer;
        int Max;
        DateTime dt;
        object _sync;
        public ThrottleTimer(TimerCallback action, int max)
        {
            _sync = new object();
            Max = max;
            timer = new Timer(action);
        }

        public void Dispose()
        {
            if (timer == null)
                return;
            Update();
            //timer.Dispose();
        }

        public void Trigger()
        {
            lock (_sync)
            {
                if (dt == default)
                {
                    Debug.WriteLine("Timer tick");
                    dt = DateTime.Now;
                    Update();
                    return;
                }
                else
                {
                    var dt2 = DateTime.Now;
                    var sec = (dt2 - dt).TotalMilliseconds;
                    if (sec > Max)
                    {
                        Update();
                        dt = DateTime.Now;
                    }
                    else
                    {
                        Debug.WriteLine("Timer action debounced");
                    }
                }
            }

        }

        private void Update()
        {
            timer.Change(0, int.MaxValue);
        }
    }
}
