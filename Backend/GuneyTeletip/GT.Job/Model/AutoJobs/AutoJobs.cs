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
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Util.Job;

namespace GT.Job.Model.AutoJobs
{
    public static class AutoBussinessJobs
    {
        public static JobBussinessService AutoJobService { get; set; }

        public static JobBussinessService ManuelJobService { get; set; }

        static JobBussinessService.JobServiceItem SendKosJob { get; set; }
        static JobBussinessService.JobServiceItem MakeKosJob { get; set; }

        static AutoBussinessJobs()
        {
            AutoJobService = new JobBussinessService();
            ManuelJobService = new JobBussinessService();
            
            
        }

        public static void StartMakeKos()
        {
            MakeKosJob = AutoJobService.Create((o, ac) =>
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


