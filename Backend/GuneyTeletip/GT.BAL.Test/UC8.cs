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

            //AutoBussinessJobs.AutoJobService.
            //while (true)
            //{
            //    AutoBussinessJobs.MakeKos.Stop();
            //    AutoBussinessJobs.MakeKos.Start();
            //}

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
            t2.timer.Dispose();
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
                         Thread.Sleep(100);
                         var rnd = new Random();
                         if (o.IsCancellationRequested)
                         {
                             Debug.WriteLine("JOb is cancelled");
                             return;
                         }

                         t(new JobBussinessServiceProgressItem(rnd.Next(1000), rnd.Next(1000)));
                     }
                 });
                item.Start();
                Thread.Sleep(600);
                item.Stop();
                item.Start();
            }
        }

        [Test]
        public void UC8_Main()
        {
            BussinessJobs.StartAutomaticJobs();
            while (true)
            {
                Thread.Sleep(100);
                var item = BussinessJobs.MakeKosJob.ProgressItem;
                if(item==null)
                {
                    Debug.WriteLine($"Success:{item.Success} Error:{item.Error}");
                }
                else
                {
                    Debug.WriteLine("NO data");
                }
                
            }

        }
    }
}