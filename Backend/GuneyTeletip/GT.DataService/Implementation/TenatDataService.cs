using GT.Repository.Conditions;
using GT.Repository.Implementation;
using GT.Repository.Models.Filter;
using GT.Repository.Models.View;
using MEDLIFE.PERSISTANCE;
using MEDLIFE.SERVICE;
using MEDLIFE.UTILS.GRID;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT.DataService.Implementation
{
    public class TenatDataService : BaseService
    {
        AbstractWorkspace _Workspace;
        TenatRepository tenatRepository;
        public TenatDataService(IBussinessContext context) : base(context)
        {
            _Workspace = WorkspaceFactory.Create(true);
            tenatRepository = new TenatRepository(_Workspace);
        }

        public PagingResult<TenatViewModel> GetTenatList(Gridable<TenatViewFilter> parms)
        {
            if (parms == null)
            {
                parms = new Gridable<TenatViewFilter>();
            }
            if (parms.Filter == null)
            {
                parms.Filter = new TenatViewFilter();
            }
            var t = new TenatConditionFilter
            {
                TenatAd=parms.Filter.TenatAd
            };
            return tenatRepository.Query(t).GetGridQuery(parms);
        }
    }
}
