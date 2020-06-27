using GT.BAL.TeletipKos;
using GT.Core.Settings;
using GT.DataService.infinity.Implementation;
using GT.DataService.infinity.Model;
using GT.Job.Implementation;
using GT.Job.Model.AutoJobs;
using GT.SERVICE;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Util.Logger;
using System.Text;

namespace GT.BAL.Test
{
    /// <summary>
    /// UC1 Infinity Entegrasyon 
    /// </summary>
    public class UC8
    {
        [SetUp]
        public void Setup()
        {
        }
        /// <summary>
        /*
         * UC8 Job/Kuyruk/Servis İşlemleri
        UC8.1 Otomatik 3 Job
        Make Kos
        Kosu olmayanlar
        En az 2 saatten önce yapılmış çekimler
        Send Kos
        Kos Oluşmuşlar
        3 kere denenmişleri gönder
        STM Kos Status Update


         UC8.2 Job Listesi Getirilmesi
        Columns
        Başlangıç tarihi
        Bitiş tarihi
        Tip (MakeKos,SendKos,status check)
        Başarılı Sayısı
        Başarısız Sayısı
        Filtre
        DateRange
        Type
        JobIdList
        Job Save/Update


         */
        /// </summary>
        [Test]
        public void UC8_1()
        {

            BussinessJobs.StartAutomaticJobs();
            while (true)
            {
                Thread.Sleep(100);
                var item = BussinessJobs.SendKosJob.ProgressItem;
                if (item == null)
                {
                    Debug.WriteLine($"Success:{item.Success} Error:{item.Error}");
                }
                else
                {
                    Debug.WriteLine("NO data");
                }
            }


        }

        [Test]
        public void UC8_2()
        {

            var t2 = new ThrottleTimer(o =>
            Debug.WriteLine(DateTime.Now.ToString("yyyyMMdd hh:mm:ss:ffff"))
            , 1200);
            var i = 0;
            while (i++ < 30000000)
            {
                t2.Trigger();
            }
            t2.Dispose();
            Console.Read();
        }
        [Test]
        public void UC8_3()
        {
            var js = new JobBussinessService();

            while (true)
            {

                var item = js.Create((o, t) =>
                {
                    int i = 0;
                    while (true)
                    {
                        Debug.WriteLine($"ThreadID:{Thread.CurrentThread.ManagedThreadId}\t{i++}");
                        Thread.Sleep(20);

                        var rnd = new Random();
                        if (rnd.Next(1000) == 1)
                        {
                            // throw new Exception("GÖRÜNDÜN MÜ HATAYI");
                        }

                        if (o.IsCancellationRequested)
                        {
                            Debug.WriteLine("JOb is cancelled");
                            return;
                        }
                        if (rnd.Next(2) == 1)
                        {
                            t.IncreaseProgressSuccess();
                        }
                        else
                        {
                            t.IncreaseProgressError();
                        }
                    }
                });
                item.Start();
                Thread.Sleep(2000);
                item.Stop();
            }
        }
        [Test]
        public void UC8_5()
        {
            var sd = new StudyKosService(null);
            var job = sd.DeleteKosBackground(new DataService.Model.InfStudyFilter());
            while (true)
            {
                Thread.Sleep(100);
                Debug.WriteLine($"Success:{job.ProgressItem.Success} Error:{ job.ProgressItem.Error}");
            }
        }




        [Test]
        public void UC8_6()
        {

            var gelen_app_setting = File.ReadAllText("appsettings.json");

            var y = JsonConvert.DeserializeObject<string>(gelen_app_setting);




        }

        public class TypeJson
        {
            public string patientId { get; set; }
            public string KOS { get; set; }
            public string RepositoryUr { get; set; }
            public string Result { get; set; }

            public TypeJson()
            {
            }


        }




        public class HighLowTemps
        {
            public string isSuccess { get; set; }
            public string message { get; set; }

            public string arguments { get; set; }
        }


    }
}