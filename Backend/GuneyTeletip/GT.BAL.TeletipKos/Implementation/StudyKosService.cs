using GT.BAL.TeletipKos.Model;
using GT.Core.Settings;
using GT.DataService.Implementation;
using GT.DataService.Model;
using GT.Job.Implementation;
using GT.Job.Model.AutoJobs;
using GT.Repository.Models.View;
using GT.Repository.Models.View.Composite;
using GT.SERVICE;
using GT.UTILS.GRID;
using System.Collections.Generic;
using System.Linq;
using Util.Extensions;

namespace GT.BAL.TeletipKos
{
    public class StudyKosService
    {
        private readonly StudyKosDataService _InfStudyDataService;
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

        public MultipleOperationResultModel CreateKosJson(Gridable<KosStudyFilter> filter)
        {
            var op = new MakeKosOperation();

            var studyDataService = new StudyKosDataService();
            var list = studyDataService.GetMakeKosWithIntanceList(10);


            var resList = op.DoSingleBatchJSON(list)
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
                    {
                        return;
                    }

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

                    var items = studyDataService.GetSentKosList(100);
                    if (items.Count == 0)
                    {
                        return;
                    }

                    var mc = new SendKosOperation();
                    mc.DoSingleBatch(items, o, ac);
                }
            });

            job.Start();
            return job;
        }






        public MultipleOperationResultModel DeleteKos(Gridable<KosStudyFilter> filter)
        {
            var op = new STMKosDeleteOperation();

            var studyDataService = new StudyKosDataService();
            var list = studyDataService.GetKosDeleteListGrid(filter);
            var resList = op.DoSingleBatch(list);
           
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
                var items = studyDataService.GetKosDurumOrderList(filter);

                var mc = new STMOrderStatusForAccessionNumberListOperation(0);
                mc.StmOrderList(items, o, ac);




            });
            job.Start();
            return job;
        }


        public IEnumerable<OperationResult<ReprocessStudyOperationResult>> ReProcessKos2(Gridable<KosStudyFilter> filter)
        {
            var studyDataService = new StudyKosDataService();
            var list = studyDataService.GetReprocessList(filter);

            var model = list.Select(o => new ReprocessViewModel
            {
                AccessionNumber = o.AccessionNumber,
                MedulaInstitutionID = o.MedulaInstitutionID,
                StudyID = o.StudyID
            }).ToArray();

            var opManager = new ReProcessStudyOperation();
            var multiRes = opManager.DoBatch(model);
            return multiRes;
        }




        public IEnumerable<OperationResult<ReprocessStudyOperationResult>> ReProcessKos(Gridable<KosStudyFilter> filter)
        {
            var studyDataService = new StudyKosDataService();
            var list = studyDataService.GetReprocessList(filter);

            var model = list.Select(o => new ReprocessViewModel
            {
                AccessionNumber = o.AccessionNumber,
                MedulaInstitutionID = o.MedulaInstitutionID,
                StudyID = o.StudyID
            }).ToArray();

            var opManager = new ReProcessStudyOperation();
            var multiRes = opManager.DoBatch(model);
            return multiRes;
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
