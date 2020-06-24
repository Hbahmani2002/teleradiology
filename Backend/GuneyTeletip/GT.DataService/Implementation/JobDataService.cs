using Gt.PERSISTANCE;
using GT.DataService.Model;
using GT.Persistance.Domain.Models;
using GT.Repository.Conditions;
using GT.Repository.Implementation;
using GT.Repository.Implementation.Composite;
using GT.Repository.Models.View;
using GT.SERVICE;
using GT.UTILS.GRID;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT.DataService.Implementation
{
    public class JobDataService : BaseService
    {
        AbstractWorkspace _Workspace;
        JobCompositeRepository jobCompositeRepository;
        EnumTypeJobRepository enumTypeJobRepository;
        KosStudyJobRepository kosStudyJobRepository;
        public JobDataService(IBussinessContext context) : base(context)
        {
            _Workspace = GTWorkspaceFactory.Create(true);
            jobCompositeRepository = new JobCompositeRepository(_Workspace);
            enumTypeJobRepository = new EnumTypeJobRepository(_Workspace);
            kosStudyJobRepository = new KosStudyJobRepository(_Workspace);
        }
      
        public PagingResult<JobViewmodel> GetJobList(Gridable<JobViewFilter> parms)
        {
            if (parms == null)
            {
                parms = new Gridable<JobViewFilter>();
            }
            if (parms.Filter == null)
            {
                parms.Filter = new JobViewFilter();
            }
            var e = new EnumTypeJobConditionFilter { Name=parms.Filter.EnumType};
            var k = new KosStudyJobConditionFilter { IDList=parms.Filter.JobIDList,
                TimeStart=parms.Filter.BasTarih,
                TimeStop=parms.Filter.BitTarih };
            return jobCompositeRepository.Query(e,k).GetGridQuery(parms);
        }
        public enum JopEnumType
        {
            MakeKos=1,
            SendKos=2,
            StatusCheck=3
        }
        public long Save(DateTime basTar, JopEnumType tip)
        {
            var kosStudyJob = new KosStudyJob();
            kosStudyJob.TimeStart = basTar;
            kosStudyJob.TimeCreated = DateTime.Now;
            kosStudyJob.FkJobEnumType = (int)tip;
            kosStudyJob.FkUserCreated = Context.UserInfo.UserIDCurrent;
            kosStudyJobRepository.Add(kosStudyJob);
            _Workspace.CommitChanges();
            return kosStudyJob.Pk;
        }
        public long SaveProgress(long id, DateTime progressTarih, long? basariliSayisi, long? basarisizSayisi)
        {
            var kosStudyJob = kosStudyJobRepository.GetByID(id);
            kosStudyJob.ErrorCount = basarisizSayisi;
            kosStudyJob.TimeStop = progressTarih;
            kosStudyJob.TimeModified = DateTime.Now;
            kosStudyJob.SuccessfulCount = basariliSayisi;
            kosStudyJob.FkUserModified = Context.UserInfo.UserIDCurrent;
            kosStudyJobRepository.Update(kosStudyJob);
            _Workspace.CommitChanges();
            return kosStudyJob.Pk;
        }
        public long UpdateAndClose(long id,DateTime? bitTar)
        {
            var kosStudyJob = kosStudyJobRepository.GetByID(id);
            kosStudyJob.TimeStop = bitTar;
            kosStudyJob.TimeModified = DateTime.Now;
            kosStudyJob.FkUserModified = Context.UserInfo.UserIDCurrent;
            kosStudyJobRepository.Update(kosStudyJob);
            _Workspace.CommitChanges();
            return kosStudyJob.Pk;
        }
    }
}
