using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;

namespace Util.Job.Interface
{
    public class JobManager
    {
        private Dictionary<string, JobItem> _Jobs;
        public ReadOnlyDictionary<string, JobItem> JobItems { get; }
        public JobManager()
        {
            _Jobs = new Dictionary<string, JobItem>();
            JobItems = new ReadOnlyDictionary<string, JobItem>(_Jobs);
        }
        public JobItem Register(string name, int interval, Action action)
        {
            var item = new JobItem(interval, action);
            _Jobs.Add(name, item);
            return item;
        }


    }
}
