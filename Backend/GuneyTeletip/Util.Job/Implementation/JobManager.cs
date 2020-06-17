using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Util.Job.Interface
{
    public static class JobManager
    {
        public static Dictionary<string, JobItem> Jobs { get; set; }
        static JobManager()
        {
            Jobs = new Dictionary<string, JobItem>();
        }
        public static void Register(string name, JobItem job)
        {
            Jobs.Add(name, job);
        }

      
    }
}
