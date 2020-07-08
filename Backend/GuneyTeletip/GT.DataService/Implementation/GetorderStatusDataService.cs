using Gt.PERSISTANCE;
using GT.DataService.Model;
using GT.Repository.Conditions;
using GT.Repository.Implementation;
using GT.Repository.Implementation.Composite;
using GT.Repository.Models.View;
using GT.SERVICE;
using GT.UTILS.GRID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GT.DataService.Implementation
{
    public class GetorderStatusDataService : BaseService
    {
        AbstractWorkspace _Workspace;
        TeletipStatusRepository teletipStatusRepository;
        GetOrderStatusforAccessionNumberRepository getOrderStatusforAccessionNumberRepository;
        public GetorderStatusDataService(IBussinessContext context) : base(context)
        {
            _Workspace = GTWorkspaceFactory.Create(false);
            teletipStatusRepository = new TeletipStatusRepository(_Workspace);
            getOrderStatusforAccessionNumberRepository = new GetOrderStatusforAccessionNumberRepository(_Workspace);
        }

        public List<TeletipStatusViewModel> GetTeletipStatusList()
        {
            return teletipStatusRepository.Query().ToList();
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
            var g = new GetorderStatusConditionFilter
            {
                BitTar=parms.Filter.BitTar,
                BasTar=parms.Filter.BasTar,
                HastaneIDList=parms.Filter.HastaneIDList,
                TeletipStatusIDList=parms.Filter.TeletipStatusIDList
            };
            return getOrderStatusforAccessionNumberRepository.Query(g).GetGridQuery(parms);
        }
    }
}
