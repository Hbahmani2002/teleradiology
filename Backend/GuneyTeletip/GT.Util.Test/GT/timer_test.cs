using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Util.Job.Interface;
using System.Linq;
using System.Threading;
using System.Diagnostics;

namespace GT.Test.GT
{
    public class timertest
    {
        [SetUp]
        public void Setup()
        {
        }




        [Test]
        public void Test1()
        {


            var JobManager = new JobManager();



            JobManager.Register("job1", 1000, ActionTest);
            JobManager.Register("job2", 1000, ActionTest);
            JobManager.Register("job3", 1000, ActionTest);
            JobManager.JobItems.ToList().ForEach(o => o.Value.Start());
            Thread.Sleep(5000);
            JobManager.JobItems.ToList().ForEach(o => o.Value.Stop());
            //var job = JobManager.Jobs()

        }


        private void ActionTest()
        {

            Debug.WriteLine("in....");


        }

    }
}
