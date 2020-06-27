using App.Data.Service;
using GT.BAL.TeletipKos.Model;
using GT.Core.Settings;
using GT.DataService.Implementation;
using GT.DataService.Model;
using GT.Job.Implementation;
using GT.Job.Model.AutoJobs;
using GT.Repository.Models.View;
using GT.SERVICE;
using GT.UTILS.GRID;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Teletip.SorgulamaServis;
using Util.Extensions;

namespace GT.BAL.TeletipKos
{
    public class StudyKosService
    {
        StudyKosDataService _InfStudyDataService;
        public StudyKosService(IBussinessContext context)
        {
            _InfStudyDataService = new StudyKosDataService(context);
        }

        public MultipleOperationResultModel CreateKos(InfStudyFilter filter)
        {

            var list = GetStudyKos(filter);
            foreach (var item in list)
            {

            }
            return RandomDataGenerator.CreateRandom<MultipleOperationResultModel>(1).FirstOrDefault();
        }
        //public MultipleOperationResultModel CreateKosBackground1(InfStudyFilter filter)
        //{

        //    var list = GetStudyKos(filter);
        //    CreateKos(list);

        //}



        public MultipleOperationResultModel MakeKos(InfStudyFilter filter)
        {
            var list = GetStudyKos(filter);
            foreach (var item in list)
            {

            }
            return RandomDataGenerator.CreateRandom<MultipleOperationResultModel>(1).FirstOrDefault();
        }
        public JobBussinessService.JobServiceItem CreateKosBackground(InfStudyFilter filter)
        {

            var job = BussinessJobs.ManuelJobService.Create((o, ac) =>
            {

                var log = new AppLogDataService(null);
                try
                {
                    var globalSettings = AppSettings.GetCurrent();
                    var studyDataService = new StudyKosDataService();
                    while (true)
                    {
                        var items = studyDataService.GetMakeKosList(50);
                        if (items.Count == 0)
                            return;

                        var mc = new MakeKosOperation();
                        mc.DoSingleBatch(items, o, ac);
                    }

                }
                catch (Exception ex)
                {

                    var fileName = $"{DateTime.Now.ToString("yyyyMMddhhmmss_ffff")}.log";
                    var filePath = Path.Combine(AppSettings.GetCurrent().Log.DIR_JobsLogManuel, fileName);
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                    File.WriteAllText(filePath, ex.ToString());
                    log.Save(AppLogDataService.LogType.BackGroundJobs, "Log File Path:" + filePath);
                }




            });

            job.Start();
            return job;
        }



        public JobBussinessService.JobServiceItem SendKosBackground(InfStudyFilter filter)
        {

            var job = BussinessJobs.ManuelJobService.Create((o, ac) =>
            {

                var log = new AppLogDataService(null);
                try
                {
                    var globalSettings = AppSettings.GetCurrent();
                    var studyDataService = new StudyKosDataService();
                    while (true)
                    {
                        var items = studyDataService.GetSentKosList(50);
                        if (items.Count == 0)
                            return;

                        var mc = new SendKosOperation();
                        mc.DoSingleBatch(items, o, ac);
                    }

                }
                catch (Exception ex)
                {

                    var fileName = $"{DateTime.Now.ToString("yyyyMMddhhmmss_ffff")}.log";
                    var filePath = Path.Combine(AppSettings.GetCurrent().Log.DIR_JobsLogManuel, fileName);
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                    File.WriteAllText(filePath, ex.ToString());
                    log.Save(AppLogDataService.LogType.BackGroundJobs, "Log File Path:" + filePath);
                }




            });

            job.Start();
            return job;
        }




        public JobBussinessService.JobServiceItem DeleteKos(Gridable<InfStudyFilter> filter)
        {
            return null;
        }

        public JobBussinessService.JobServiceItem DeleteKosBackground(InfStudyFilter filter)
        {
            var job = BussinessJobs.ManuelJobService.Create((o, ac) =>
            {

                try
                {
                    var globalSettings = AppSettings.GetCurrent();
                    var studyDataService = new StudyKosDataService();
                    var items = studyDataService.GetKosDeleteList(filter);
                    var mc = new STMKosDeleteOperation();
                    mc.DoSingleBatch(items, o, ac);
                }
                catch (Exception ex)
                {
                    var fileName = $"{DateTime.Now.ToString("yyyyMMddhhmmss_ffff")}.log";
                    var filePath = Path.Combine(AppSettings.GetCurrent().Log.DIR_JobsLogManuel, fileName);
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                    File.WriteAllText(filePath, ex.ToString());
                    throw new Exception("Delete Kos" + "Log File Path:" + filePath);
                }

            });
            job.Start();
            return job;
        }



        public JobBussinessService.JobServiceItem StmGetOrderStatusForAccessionNumberlistBackground(InfStudyFilter filter)
        {
            var job = BussinessJobs.ManuelJobService.Create((o, ac) =>
            {

                try
                {
                    var globalSettings = AppSettings.GetCurrent();
                    var studyDataService = new StudyKosDataService();
                    var items = studyDataService.GetKosDeleteList(filter);
                    var mc = new STMKosDeleteOperation();
                    mc.DoSingleBatch(items, o, ac);
                }
                catch (Exception ex)
                {
                    var fileName = $"{DateTime.Now.ToString("yyyyMMddhhmmss_ffff")}.log";
                    var filePath = Path.Combine(AppSettings.GetCurrent().Log.DIR_JobsLogManuel, fileName);
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                    File.WriteAllText(filePath, ex.ToString());
                    throw new Exception("Delete Kos" + "Log File Path:" + filePath);
                }

            });
            job.Start();
            return job;
        }



        public void ReprocessKos(InfStudyFilter filter)
        {
            var list = GetStudyKos(filter);
            foreach (var item in list)
            {

            }
            throw new NotImplementedException();
        }

        public JobBussinessService.JobServiceItem ReprocessKosBackground(InfStudyFilter filter)
        {
            var job = BussinessJobs.ManuelJobService.Create((o, ac) =>
            {

                try
                {
                    var globalSettings = AppSettings.GetCurrent();
                   
                   
                }
                catch (Exception ex)
                {
                    var fileName = $"{DateTime.Now.ToString("yyyyMMddhhmmss_ffff")}.log";
                    var filePath = Path.Combine(AppSettings.GetCurrent().Log.DIR_JobsLogManuel, fileName);
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                    File.WriteAllText(filePath, ex.ToString());
                    throw new Exception("Delete Kos" + "Log File Path:" + filePath);
                }

            });
            job.Start();
            return job;
        }

        public void UpdateReadKos(InfStudyFilter filter)
        {
            var list = GetStudyKos(filter);
            foreach (var item in list)
            {

            }
            throw new NotImplementedException();
        }

        public void UpdateReadKosBackground(InfStudyFilter filter)
        {
            var list = GetStudyKos(filter);
            foreach (var item in list)
            {

            }
            throw new NotImplementedException();
        }

        public void ExportExcel(InfStudyFilter filter, string filePath)
        {
            var list = GetStudyKos(filter);
            foreach (var item in list)
            {

            }
        }

        private IEnumerable<InfStudyViewModel> GetStudyKos(InfStudyFilter filter)
        {
            var grid = new Gridable<InfStudyFilter>();
            grid.Paging.Count = 1000;
            grid.Filter = filter;

            // var list = _InfStudyDataService.GetInfStudyList(grid).List;
            // return list;
            return RandomDataGenerator.CreateRandom<InfStudyViewModel>(12).ToList();
        }

    }
}
