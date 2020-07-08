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
    public class GetorderStatusDataService : BaseService
    {
        AbstractWorkspace _Workspace;
        public GetorderStatusDataService(IBussinessContext context) : base(context)
        {
            _Workspace = GTWorkspaceFactory.Create(false);
        }

        public PagingResult<GetorderStatusViewModel> GetGetorderStatusList(Gridable<GetorderStatusViewFilter> parms)
        {
            if (parms == null)
            {
                parms = new Gridable<GetorderStatusViewFilter>();
            }
            if (parms.Filter == null)
            {
                parms.Filter = new GetorderStatusViewFilter();
            }
            var k = new InfStudyConditionFilter
            {

            };
            return null;
        }
    }
}
