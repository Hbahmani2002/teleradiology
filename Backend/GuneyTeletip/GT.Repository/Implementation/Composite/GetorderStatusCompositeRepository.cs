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
        public IEnumerable<GetorderStatusViewModel> Query(GetorderStatusConditionFilter g)
        {
            var exp1 = GetorderStatusCondition.Get(g);
            return Query(exp1);
        }
        
        public IEnumerable<GetorderStatusViewModel> Query(Expression<Func<StmGetorderStatusforAccessionnumberlist, bool>> exp)
        {
            var getorderStatus = _AbstractWorkspace.Query<StmGetorderStatusforAccessionnumberlist>(exp);
            var skrs = _AbstractWorkspace.Query<ConstSkrs>();
            var userSkrs = _AbstractWorkspace.Query<UsrTenantSkrs>();
            var list = from gs in getorderStatus
                       join us in userSkrs on gs.FkTenant equals us.FkTenant
                       join s in skrs on us.FkSkrs equals s.Pk
                       select new GetorderStatusViewModel
                       {
                          Accessionnumber=gs.Accessionnumber,
                          Citizenid=gs.Citizenid,
                          Dosestatus=gs.Dosestatus,
                          Dosestatusid=gs.Dosestatusid.Value,
                          Error=gs.Error,
                          FkInfBatch=gs.FkInfBatch,
                          FkKosStudy=gs.FkKosStudy,
                          FkTenant=gs.FkTenant,
                          Lastmedulasenddate=gs.Lastmedulasenddate,
                          Medulainstitutionid=gs.Medulainstitutionid,
                          Medularesponsecode=gs.Medularesponsecode,
                          Medularesponsemessage=gs.Medularesponsemessage,
                          Medulastatus=gs.Medulastatus,
                          Medulastatusid=gs.Medulastatusid.Value,
                          Patienthistorysearchstatus=gs.Patienthistorysearchstatus,
                          Patienthistorysearchstatusid=gs.Patienthistorysearchstatusid,
                          Performeddate=gs.Performeddate,
                          Reportstatus=gs.Reportstatus,
                          Reportstatusid=gs.Reportstatusid.Value,
                          Scheduledate=gs.Scheduledate,
                          Teletipstatus=gs.Teletipstatus,
                          Teletipstatusid=gs.Teletipstatusid.Value,
                          Sutcode=gs.Sutcode,
                          Wadostatus=gs.Wadostatus,
                          Wadostatusid=gs.Wadostatusid.Value,
                          ID=gs.Pk,
                          SkrsKod=s.KurumSkrsKodu
                       };
            return list;
        }
    }
}
