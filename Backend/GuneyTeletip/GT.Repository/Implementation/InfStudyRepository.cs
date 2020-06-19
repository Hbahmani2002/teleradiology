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


    public class InfStudyRepository : AbstractTableRepository<InfStudy>
    {

        public InfStudyRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }

        public override InfStudy GetByID(int id)
        {
            return Single(o => o.Pk == id);
        }

        public IQueryable<InfStudyViewModel> Query(InfStudyConditionFilter filter)
        {
            var exp = InfStudyCondition.Get(filter);
            return Query(exp);
        }

        public IQueryable<InfStudyViewModel> Query(Expression<Func<InfStudy, bool>> exp)
        {
            var userLogin = _AbstractWorkspace.Query<UsrUserLogin>();
            var infStudiesLogin = _AbstractWorkspace.Query<InfStudy>(exp);
            var list = from s in infStudiesLogin
                      // join u in userLogin on s.OracleStudyKey equals u.Pk
                       select new InfStudyViewModel
                       {
                           AccessionNumber=s.AccessionNo,
                           IstemAdi="",
                           HastaNo=s.PatientId,
                           ID=s.Pk,
                           PatientName=s.PatinetNameSurname,
                           Modality=s.Modality,
                           KosStateTag=s.StudyDescription,
                           CihazDeviceSerialNumber=s.CihazDeviceSerialNumber,
                           CreationDttm=s.CreationDttm,
                           DateBirth=s.DateBirth,
                           Desc1=s.Desc1,
                           Desc2=s.Desc2,
                           SeriesCount=s.SeriesCount,
                           Desc3=s.Desc3,
                           FileName=s.FileName,
                           InfBatchID=s.FkInfBatch,
                           TenantID=s.FkTenant,
                           Gender=s.Gender,
                           InstanceCount=s.InstanceCount,
                           OracleStudyKey=s.OracleStudyKey,
                           Institution=s.Institution,
                           SeriesKey=s.SeriesKey,
                           InstanceKey=s.InstanceKey,
                           InstitutionName=s.InstitutionName,
                           StudyDate=s.StudyDate,
                           PatientID=s.PatientId,
                           TimeModified=s.TimeModified,
                           StudyDescription=s.StudyDescription,
                           UserIDCreated=s.FkUserCreated,
                           UserIDModfiead=s.FkUserModfiead,
                           TimeCreated=s.TimeCreated,
                           ValumeCode=s.ValumeCode,
                           ValumePathname=s.ValumePathname,
                           ValumeStat=s.ValumeStat,
                           StudyInstanceuid=s.StudyInstanceuid,
                           ValumeType=s.ValumeType,
                           StoragePath=s.StoragePath
                       };

            return list;
        }
    }
}
