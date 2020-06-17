using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Util.Job.Interface
{
    public class JobItem
    {
        //Timer tm = null;
        Timer tm = null;
        //private System.Timers.Timer sTimer { get; set; }
        public int xInterval { get; set; }
        public Action Action { get; set; }
        private int _counter = 0;

        //public JobItem(int interval, string name, Action action)
        public JobItem(int interval, Action action)
        {
            xInterval = interval;
            Action = action;


        }



        public void Start()
        {


            tm = new Timer(o =>
            {
                Action();
            }, null, 1000, xInterval);

        }

        

        public void Stop()
        {
            
            tm.Dispose();
        }







        public static string GetCredentials()
        {


            return "";
        }

    }
}
