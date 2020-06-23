using Gt.PERSISTANCE;
using GT.DataService.Model;
using GT.Repository.Conditions;
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
        public JobDataService(IBussinessContext context) : base(context)
        {
            _Workspace = GTWorkspaceFactory.Create(true);
            jobCompositeRepository = new JobCompositeRepository(_Workspace);
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

        public int Save(DateTime basTar, DateTime bitTar, string tip, long basariliSayisi, long basarisizSayisi)
        {
            return 1;
        }
    }
}
