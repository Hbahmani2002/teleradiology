using GT.BAL.Infinity.DataSynronizer;
using GT.Core.Settings;
using GT.DataService.infinity.Implementation;
using GT.DataService.infinity.Model;
using GT.Job.Implementation;
using GT.Job.Model.AutoJobs;
using GT.SERVICE;
using NUnit.Framework;
using System;
using System.Diagnostics;
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
            var settings = AppSettings.GetCurrent();
            var ks = settings.DataServiceSettings;
            var filePath = AppSettings.GetCurrent().Log.PATH_JobInfinity;
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));

            var logger = new TextFileLogger(filePath);
            var jobManager = InfJobManager.Create(logger);
            jobManager.Start();
            Thread.Sleep(100000000);

        }

        [Test]
        public void UC11()
        {
            var ex = AppSettings.GetCurrent().ConfigFileException;
            var dc = new InfinityDataSyncronizer(null);
            dc.SyncronizeInfinityStudyList(5, 0, new DateTime(2020, 08, 07), new DateTime(2020, 08, 08));



        }

    }
}