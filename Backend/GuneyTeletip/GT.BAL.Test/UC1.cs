using GT.Core.Settings;
using GT.DataService.infinity.Implementation;
using GT.DataService.infinity.Model;
using GT.Job.Implementation;
using GT.SERVICE;
using NUnit.Framework;
using System;
using System.IO;
using System.Threading;
using Util.Logger;

namespace GT.BAL.Test
{
    /// <summary>
    /// UC1 Infinity Entegrasyon 
    /// </summary>
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// UC1.1. Job
        /// </summary>
        /// 

   
        [Test]
        public void UC1()
        {

            var filePath = AppSettings.GetCurrent().Log.PATH_JobInfinity;
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));

            var logger = new TextFileLogger(filePath);
            var jobManager = InfJobManager.Create(logger);
            jobManager.Start();
            Thread.Sleep(10000);



       
           



        }

    }
}