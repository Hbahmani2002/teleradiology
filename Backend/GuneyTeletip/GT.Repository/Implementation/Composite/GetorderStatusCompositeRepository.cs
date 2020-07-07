using Gt.PERSISTANCE;
using GT.Persistance.Domain.Models;
using GT.Repository.Conditions;
using GT.Repository.Models.View;
using GT.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GT.Repository.Implementation.Composite
{
    public class GetorderStatusCompositeRepository : AbstractRepository
    {
        public GetorderStatusCompositeRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }
        public IEnumerable<GetorderStatusViewModel> Query(GetorderStatusConditionFilter g, InfStudyConditionFilter k)
        {
            var exp1 = GetorderStatusCondition.Get(g);
            var exp2 = InfStudyCondition.Get(k);
            return Query(exp1,exp2);
        }

        public IEnumerable<GetorderStatusViewModel> Query(Expression<Func<StmGetorderStatusforAccessionnumberlist, bool>> exp1,
            Expression<Func<KosStudy, bool>> exp2)
        {
            var getorderStatus = _AbstractWorkspace.Query<StmGetorderStatusforAccessionnumberlist>(exp1);
            var tenant = _AbstractWorkspace.Query<UsrTenant>();
            var batch = _AbstractWorkspace.Query<KosBatch>();
            var kos = _AbstractWorkspace.Query<KosStudy>(exp2);
            var list = from gs in getorderStatus
                       join t in tenant on gs.FkTenant equals t.Pk
                       join b in batch on gs.FkInfBatch equals b.Pk
                       join k in kos on gs.FkKosStudy equals k.Pk
                       select new GetorderStatusViewModel
                       {
                          Accessionnumber=gs.Accessionnumber,
                          Citizenid=gs.Citizenid,
                          Dosestatus=gs.Dosestatus,
                          Dosestatusid=gs.Dosestatusid,
                          Error=gs.Error,
                          FkInfBatch=gs.FkInfBatch,
                          FkKosStudy=gs.FkKosStudy,
                          FkTenant=gs.FkTenant,
                          Lastmedulasenddate=gs.Lastmedulasenddate,
                          Medulainstitutionid=gs.Medulainstitutionid,
                          Medularesponsecode=gs.Medularesponsecode,
                          Medularesponsemessage=gs.Medularesponsemessage,
                          Medulastatus=gs.Medulastatus,
                          Medulastatusid=gs.Medulastatusid,
                          Patienthistorysearchstatus=gs.Patienthistorysearchstatus,
                          Patienthistorysearchstatusid=gs.Patienthistorysearchstatusid,
                          Performeddate=gs.Performeddate,
                          Reportstatus=gs.Reportstatus,
                          Reportstatusid=gs.Reportstatusid,
                          Scheduledate=gs.Scheduledate,
                          Teletipstatus=gs.Teletipstatus,
                          Teletipstatusid=gs.Teletipstatusid,
                          Sutcode=gs.Sutcode,
                          Wadostatus=gs.Wadostatus,
                          Wadostatusid=gs.Wadostatusid,
                          ID=gs.Pk,
                          TenantName=t.Name,
                          CitizenID=gs.Citizenid
                       };
            return list;
        }
    }
}
