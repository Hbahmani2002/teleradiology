using Gt.PERSISTANCE;
using GT.DataService.infinity.Conditions;
using GT.DataService.infinity.Model;
using GT.PERSISTANCE;
using GT.Repository.infinity.Conditions;
using GT.Repository.infinity.Implementation.CompositeView;
using GT.Repository.infinity.Model.View;
using GT.SERVICE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GT.DataService.infinity.Implementation
{
    public class KosInstanceDataService : BaseService
    {
        AbstractWorkspace _Workspace;
        KosInstanceCompositeRepository kosInstanceCompositeRepository;
        public KosInstanceDataService(IBussinessContext context) : base(context)
        {
            _Workspace = InfWorkspaceFactory.Create(true);
            kosInstanceCompositeRepository = new KosInstanceCompositeRepository(_Workspace);
        }

        public List<KosInstanceViewModel> KosInstanceOracleList(KosInstanceViewFilter filter)
        {
            var f = new InfStudyConditionFilter { PatientID=filter.PatientID};
            var s = new SeriesConditionFilter { SeriesInfo = filter.SeriesInfo };
            var gelenList = kosInstanceCompositeRepository.Query(f,s).ToList();
            var list = gelenList
                  .Where(o => (o.SeriesInfo == filter.SeriesInfo) && (o.PatientID==filter.PatientID))
                  .OrderBy(o => o.StudyKey)
                  .Skip(0)
                  .Take(500)
                  .ToList();
            return list;
        }
    }
}
