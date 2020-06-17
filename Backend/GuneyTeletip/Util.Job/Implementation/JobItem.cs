using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Util.Job.Interface
{
    public class JobItem
    {

        Timer _timer;
        private int Interval { get; set; }
        private Action Action { get; set; }

        public JobItem(int interval, Action action)
        {
            Interval = interval;
            Action = action;
        }
        public void Start()
        {
            if (_timer != null)
            {
                throw new Exception("Timer Zaten başlamış veya yok edilmemiş");
            }
            _timer = new Timer(o =>
            {
                Action();
            }, null, 1000, Interval);

        }
        public void Stop()
        {
            _timer.Dispose();
            _timer = null;
        }







        public static string GetCredentials()
        {


            return "";
        }

    }
}
