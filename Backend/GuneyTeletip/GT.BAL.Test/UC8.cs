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

            AutoJobs.MakeKos.Start();            
            while (true)
            {
                AutoJobs.MakeKos.Stop();
                AutoJobs.MakeKos.Start();
            }

        }

    }
}