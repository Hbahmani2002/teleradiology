using Dcm4chee.DataService.Models;
using Dcm4chee.Repository.Conditions;
using Dcm4chee.Repository.Implementation;
using Dcm4chee.Repository.Implementation.Composite;
using Dcm4chee.Repository.Models;
using Gt.PERSISTANCE;
using GT.SERVICE;
using GT.UTILS.GRID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dcm4chee.DataService
{
    public class DcmDataService : BaseService
    {
        AbstractWorkspace _Workspace;
        DcmCompositeRepository dcmCompositeRepository;
        public DcmDataService(IBussinessContext context) : base(context)
        {
            _Workspace = Dcm4cheeWorkspaceFactory.Create(false);
            dcmCompositeRepository = new DcmCompositeRepository(_Workspace);
        }

        public PagingResult<DcmViewModel> Query(Gridable<DcmViewFilter> parms) {
            if (parms == null)
            {
                parms = new Gridable<DcmViewFilter>();
            }
            if (parms.Filter == null)
            {
                parms.Filter = new DcmViewFilter();
            }
            var modalityList = new string[2];
            modalityList[0] = "CT";
            modalityList[1] = "MR";
            var s = new StudyConditionFilter {
                BasTar=parms.Filter.BasTar,
                BitTar=parms.Filter.BitTar,
                AccessionNo=6
            };
            var se = new SeriesConditionFilter { ModalityList= modalityList };
            return dcmCompositeRepository.Query(s, se).GetGridQuery(parms);
        }
    }
}
