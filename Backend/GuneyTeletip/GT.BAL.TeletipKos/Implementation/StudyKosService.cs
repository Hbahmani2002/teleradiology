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

        public MultipleOperationResultModel CreateKos(Gridable<KosStudyFilter> filter)
        {
            var op = new MakeKosOperation();

            var studyDataService = new StudyKosDataService();
            var list = studyDataService.GetMakeKosList(filter);
            var resList = op.DoSingleBatch(list)
                .Select(o => new OperationResultModel()
                {
                    Id = 0,
                    Status = o.IsSuccess ? 1 : 0,
                    Description = o.Arguments + o.IsSuccess + o.Message
                }).ToArray();
            var res = new MultipleOperationResultModel(resList);
            return res;
        }


        public MultipleOperationResultModel SendKos(Gridable<KosStudyFilter> filter)
        {
            var op = new SendKosOperation();

            var studyDataService = new StudyKosDataService();
            var list = studyDataService.GetSentKosList(filter);
            var resList = op.DoSingleBatch(list)
                .Select(o => new OperationResultModel()
                {
                    Id = 0,
                    Status = o.IsSuccess ? 1 : 0,
                    Description = o.Arguments + o.IsSuccess + o.Message
                }).ToArray();
            var res = new MultipleOperationResultModel(resList);
            return res;
        }


        //public MultipleOperationResultModel CreateKosBackground1(KosStudyFilter filter)
        //{

        //    var list = GetStudyKos(filter);
        //    CreateKos(list);

        //}



        public MultipleOperationResultModel MakeKos(KosStudyFilter filter)
        {
            var list = GetStudyKos(filter);
            foreach (var item in list)
            {

            }
            return RandomDataGenerator.CreateRandom<MultipleOperationResultModel>(1).FirstOrDefault();
        }
        public JobBussinessService.JobServiceItem CreateKosBackground(KosStudyFilter filter)
        {

            var job = BussinessJobs.ManuelJobService.Create((o, ac) =>
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

            });

            job.Start();
            return job;
        }



        public JobBussinessService.JobServiceItem SendKosBackground(KosStudyFilter filter)
        {

            var job = BussinessJobs.ManuelJobService.Create((o, ac) =>
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
            });

            job.Start();
            return job;
        }




        public JobBussinessService.JobServiceItem DeleteKos(Gridable<KosStudyFilter> filter)
        {
            return null;
        }

        public JobBussinessService.JobServiceItem DeleteKosBackground(KosStudyFilter filter)
        {
            var job = BussinessJobs.ManuelJobService.Create((o, ac) =>
            {
                var globalSettings = AppSettings.GetCurrent();
                var studyDataService = new StudyKosDataService();
                var items = studyDataService.GetKosDeleteList(filter);
                var mc = new STMKosDeleteOperation();
                mc.DoSingleBatch(items, o, ac);
            });
            job.Start();
            return job;
        }


        public JobBussinessService.JobServiceItem StmGetOrderStatusForAccessionNumberlistBackground(KosStudyFilter filter)
        {
            var job = BussinessJobs.ManuelJobService.Create((o, ac) =>
            {
                var globalSettings = AppSettings.GetCurrent();
                var studyDataService = new StudyKosDataService();
                var items = studyDataService.GetKosDeleteList(filter);
                var mc = new STMOrderStatusForAccessionNumberListOperation();
                mc.DoSingleBatch(items, o, ac);
            });
            job.Start();
            return job;
        }



        public void ReprocessKos(KosStudyFilter filter)
        {
            var list = GetStudyKos(filter);
            foreach (var item in list)
            {

            }
            throw new NotImplementedException();
        }

        public JobBussinessService.JobServiceItem ReprocessKosBackground(KosStudyFilter filter)
        {
            var job = BussinessJobs.ManuelJobService.Create((o, ac) =>
            {
                var globalSettings = AppSettings.GetCurrent();
            });
            job.Start();
            return job;
        }

        //public void UpdateReadKos(KosStudyFilter filter)
        public MultipleOperationResultModel UpdateReadKos(Gridable<KosStudyFilter> filter)
        {



            //var globalSettings = AppSettings.GetCurrent();
            //var studyDataService = new StudyKosDataService();
            //var items = studyDataService.GetKosDurumIst(filter);
            //var mc = new STMOrderStatusForAccessionNumberListOperation();
            //mc.DoSingleBatch(items, o, ac);



            var op = new STMOrderStatusForAccessionNumberListOperation();

            var studyDataService = new StudyKosDataService();
            var list = studyDataService.GetKosDurum(filter);
            var resList = op.DoSingleBatch(list)
                .Select(o => new OperationResultModel()
                {
                    Id = 0,
                    Status = o.IsSuccess ? 1 : 0,
                    Description = o.Arguments + o.IsSuccess + o.Message
                }).ToArray();
            var res = new MultipleOperationResultModel(resList);
            return res;




            //var list = GetStudyKos(filter);
            //foreach (var item in list)
            //{

            //}
            //throw new NotImplementedException();
        }

        public void UpdateReadKosBackground(KosStudyFilter filter)
        {
            var list = GetStudyKos(filter);
            foreach (var item in list)
            {

            }
            throw new NotImplementedException();
        }

        public void ExportExcel(KosStudyFilter filter, string filePath)
        {
            var list = GetStudyKos(filter);
            foreach (var item in list)
            {

            }
        }

        private IEnumerable<InfStudyViewModel> GetStudyKos(KosStudyFilter filter)
        {
            var grid = new Gridable<KosStudyFilter>();
            grid.Paging.Count = 1000;
            grid.Filter = filter;

            // var list = _InfStudyDataService.GetInfStudyList(grid).List;
            // return list;
            return RandomDataGenerator.CreateRandom<InfStudyViewModel>(12).ToList();
        }

    }
}
