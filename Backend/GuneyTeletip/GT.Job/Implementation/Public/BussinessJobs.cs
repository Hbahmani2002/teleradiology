using App.Data.Service;
using GT.BAL.TeletipKos.Model;
using GT.Core.Settings;
using GT.DataService.Implementation;
using GT.Job.Implementation;
using GT.Persistance.Domain.Models;
using GT.TeletipKos;
using GT.UTILS.GRID;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Util.Job;

namespace GT.Job.Model.AutoJobs
{
    public static class BussinessJobs
    {
        public static JobBussinessService AutoJobService { get; set; }

        public static JobBussinessService ManuelJobService { get; set; }

        public static JobBussinessService.JobServiceItem SendKosJob { get; set; }
        public static JobBussinessService.JobServiceItem MakeKosJob { get; set; }

        public static JobBussinessService.JobServiceItem STMJob { get; set; }

        static BussinessJobs()
        {
            AutoJobService = new JobBussinessService();
            ManuelJobService = new JobBussinessService();
        }

        public static void StartAutomaticJobs()
        {
            MakeKosJob = AutoJobService.Create((o, ac) =>
            {

                var log = new AppLogDataService(null);
                while (true)
                {
                    try
                    {
                        var globalSettings = AppSettings.GetCurrent();
                        var studyDataService = new StudyKosDataService();
                        var items = studyDataService.GetMakeKosList(globalSettings.DataServiceSettings.MakeKosServiceItemPerBatch);
                        var mc = new MakeKosJob();
                        mc.DoSingleBatch(items, o, ac);
                    }
                    catch (Exception ex)
                    {
                        var fileName = $"{DateTime.Now.ToString("yyyyMMddhhmmss_ffff")}.log";
                        var filePath = Path.Combine(AppSettings.GetCurrent().Log.DIR_JobsLogMakeKos, fileName);
                        Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                        File.WriteAllText(filePath, ex.ToString());
                        log.Save(AppLogDataService.LogType.OtomatikMakeKos, "Log File Path:" + filePath);
                        Thread.Sleep(500);
                    }
                }
            });
            MakeKosJob.Start();
            return;
            SendKosJob = AutoJobService.Create((o, ac) =>
            {

                var log = new AppLogDataService(null);
                while (true)
                {
                    try
                    {
                        var globalSettings = AppSettings.GetCurrent();
                        var studyDataService = new StudyKosDataService(null);
                        var items = studyDataService.GetMakeKosList(globalSettings.DataServiceSettings.MakeKosServiceItemPerBatch);
                        var mc = new MakeKosJob();
                        mc.DoSingleBatch(items, o, ac);
                    }
                    catch (Exception ex)
                    {
                        log.Save(AppLogDataService.LogType.OtomatikMakeKos, ex.ToString());
                        Thread.Sleep(1000);
                    }
                }
            });
            STMJob = AutoJobService.Create((o, ac) =>
            {

                var log = new AppLogDataService(null);
                while (true)
                {
                    try
                    {
                        var globalSettings = AppSettings.GetCurrent();
                        var studyDataService = new StudyKosDataService(null);
                        var items = studyDataService.GetMakeKosList(globalSettings.DataServiceSettings.MakeKosServiceItemPerBatch);
                        var mc = new MakeKosJob();
                        mc.DoSingleBatch(items, o, ac);
                    }
                    catch (Exception ex)
                    {
                        log.Save(AppLogDataService.LogType.OtomatikMakeKos, ex.ToString());
                        Thread.Sleep(1000);
                    }
                }
            });
        }
    }
}


