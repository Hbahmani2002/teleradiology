using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Util.Job.Interface;
using System.Linq;
using System.Threading;

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

            JobItem jop = new JobItem(1000, ActionTest);
            //jop.Start();

         

                JobManager.Register("job1", jop);
                JobManager.Register("job2", jop);
                JobManager.Register("job3", jop);
                JobManager.Register("job4", jop);
                jop.Start();

            Thread.Sleep(5000);
            jop.Stop();
            //var job = JobManager.Jobs()

        }


        private void ActionTest()
        {
         
            int x = JobManager.Jobs.Count();
           
            for (int i = 1; i <= JobManager.Jobs.Count(); i++)
            {
                
            }


        }
        
    }
}
