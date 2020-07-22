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

namespace GT.Repository.Implementation
{
  public class GetOrderStatusforAccessionNumberRepository : AbstractTableRepository<StmGetorderStatusforAccessionnumberlist>
    {
        public GetOrderStatusforAccessionNumberRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }

        public override StmGetorderStatusforAccessionnumberlist GetByID(long id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<GetorderStatusViewModel> Query(GetorderStatusConditionFilter g)
        {
            var exp = GetorderStatusCondition.Get(g);
            return Query(exp);
        }

        public IQueryable<GetorderStatusViewModel> Query(Expression<Func<StmGetorderStatusforAccessionnumberlist, bool>> exp)
        {
            var getorderStatus = _AbstractWorkspace.Query<StmGetorderStatusforAccessionnumberlist>(exp);
            var list = from gs in getorderStatus
                       select new GetorderStatusViewModel
                       {
                           Accessionnumber = gs.Accessionnumber,
                           Citizenid = gs.Citizenid,
                           Dosestatus = gs.Dosestatus,
                           Dosestatusid = gs.Dosestatusid.Value,
                           Error = gs.Error,
                           FkInfBatch = gs.FkInfBatch,
                           FkKosStudy = gs.FkKosStudy,
                           FkTenant = gs.FkTenant,
                           Lastmedulasenddate = gs.Lastmedulasenddate,
                           Medulainstitutionid = gs.Medulainstitutionid,
                           Medularesponsecode = gs.Medularesponsecode,
                           Medularesponsemessage = gs.Medularesponsemessage,
                           Medulastatus = gs.Medulastatus,
                           Medulastatusid = gs.Medulastatusid.Value,
                           Patienthistorysearchstatus = gs.Patienthistorysearchstatus,
                           Patienthistorysearchstatusid = gs.Patienthistorysearchstatusid,
                           Performeddate = gs.Performeddate,
                           Reportstatus = gs.Reportstatus,
                           Reportstatusid = gs.Reportstatusid.Value,
                           Scheduledate = gs.Scheduledate,
                           Teletipstatus = gs.Teletipstatus,
                           Teletipstatusid = gs.Teletipstatusid.Value,
                           Sutcode = gs.Sutcode,
                           Wadostatus = gs.Wadostatus,
                           Wadostatusid = gs.Wadostatusid.Value,
                           ID = gs.Pk,
                       };
            return list;
        }
    }
}
