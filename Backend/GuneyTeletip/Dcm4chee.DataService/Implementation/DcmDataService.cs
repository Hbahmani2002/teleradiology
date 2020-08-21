using Dcm4chee.DataService.Model;
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

        public List<DcmViewModelNew> Query(ProtekOracleFilter filter,int count) {

            var s = new StudyConditionFilter {
                BasTar=filter.BasTar.Date.ToString(),
                BitTar=filter.BitTar.Date.ToString(),
                ID=filter.StudyID
            };
            var se = new SeriesConditionFilter { ModalityList= filter.ModalityList};
            return dcmCompositeRepository.Query(s, se).OrderBy(o => o.StudyKey).Take(count).ToList();
        }
    }
}
