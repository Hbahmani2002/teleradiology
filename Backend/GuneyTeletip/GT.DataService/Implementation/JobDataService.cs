using Gt.PERSISTANCE;
using GT.DataService.Model;
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
        public JobDataService(IBussinessContext context) : base(context)
        {
            _Workspace = GTWorkspaceFactory.Create(true);
        }

        public PagingResult<JobViewmodel> GetJobList(Gridable<JobViewFilter> parms)
        {
            return null;
        }

        public int Save(DateTime basTar, DateTime bitTar, string tip, long basariliSayisi, long basarisizSayisi)
        {
            return 1;
        }
    }
}
