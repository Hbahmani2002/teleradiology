using App.Data.Service;
using AppAbc.Data.Service;
using GT.BAL.TeletipKos.Model;
using GT.Core.Settings;
using GT.DataService.Implementation;
using GT.Job.Implementation;
using GT.Persistance.Domain.Models;
using GT.TeletipKos;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace GT.Job.Model.AutoJobs
{
    public static class BussinessJobs
    {
        public static JobBussinessService AutoJobService { get; set; }

        public static JobBussinessService ManuelJobService { get; set; }

        public static JobBussinessService.JobServiceItem SendKosJob { get; set; }
        public static JobBussinessService.JobServiceItem MakeKosJob { get; set; }
        public static JobBussinessService.JobServiceItem DicomDozJob { get; set; }

        public static JobBussinessService.JobServiceItem STMJob { get; set; }


        public static JobBussinessService.JobServiceItem STMUpdateKos { get; set; }

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
                        var mc = new MakeKosOperation();
                        mc.DoSingleBatch(items, o, ac);
                    }
                    catch (Exception ex)
                    {

                        try
                        {
                            var fileName = $"{DateTime.Now.ToString("yyyyMMddhhmmss_ffff")}.log";
                            var filePath = Path.Combine(AppSettings.GetCurrent().Log.DIR_JobsLogMakeKos, fileName);
                            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                            File.WriteAllText(filePath, ex.ToString());
                            log.Save(AppLogDataService.LogType.OtomatikMakeKos, "Log File Path:" + filePath);
                            Thread.Sleep(500);
                        }

                        catch (Exception exm)
                        {
                            log.Save(AppLogDataService.LogType.OtomatikMakeKos, "Log File Path:" + exm.Message.ToString().Substring(0, 1000));

                        }

                    }
                }
            });
            MakeKosJob.Start();

            SendKosJob = AutoJobService.Create((o, ac) =>
            {

                var log = new AppLogDataService(null);
                while (true)
                {
                    try
                    {
                        var globalSettings = AppSettings.GetCurrent();
                        var studyDataService = new StudyKosDataService(null);
                        var items = studyDataService.GetSentKosList(globalSettings.DataServiceSettings.SendKosServiceItemPerBatch);
                        var mc = new SendKosOperation();
                        mc.DoSingleBatch(items, o, ac);
                    }
                    catch (Exception ex)
                    {

                        try
                        {

                            log.Save(AppLogDataService.LogType.OtomatikSentKos, ex.ToString());
                            Thread.Sleep(1000);
                        }
                        catch(Exception exs)
                        {
                            log.Save(AppLogDataService.LogType.OtomatikSentKos, "Log File Path:" + exs.Message.ToString().Substring(0, 1000));
                            Thread.Sleep(1000);
                        }
                    
                    
                    }
                }
            });
            SendKosJob.Start();





            //DicomDozJob = AutoJobService.Create((o, ac) =>
            //{

            //    var log = new AppLogDataService(null);
            //    while (true)
            //    {
            //        try
            //        {
            //            var globalSettings = AppSettings.GetCurrent();
            //            var studyDataService = new StudyKosDataService();
            //            var items = studyDataService.GetMakeKosList(globalSettings.DataServiceSettings.MakeKosServiceItemPerBatch);
            //            var mc = new MakeKosOperation();
            //            mc.DoSingleBatch(items, o, ac);
            //        }
            //        catch (Exception ex)
            //        {

            //            try
            //            {
            //                var fileName = $"{DateTime.Now.ToString("yyyyMMddhhmmss_ffff")}.log";
            //                var filePath = Path.Combine(AppSettings.GetCurrent().Log.DIR_JobsLogMakeKos, fileName);
            //                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            //                File.WriteAllText(filePath, ex.ToString());
            //                log.Save(AppLogDataService.LogType.OtomatikMakeKos, "Log File Path:" + filePath);
            //                Thread.Sleep(500);
            //            }

            //            catch (Exception exm)
            //            {
            //                log.Save(AppLogDataService.LogType.OtomatikMakeKos, "Log File Path:" + exm.Message.ToString().Substring(0, 1000));

            //            }

            //        }
            //    }
            //});
            //DicomDozJob.Start();






        }
    }
}


