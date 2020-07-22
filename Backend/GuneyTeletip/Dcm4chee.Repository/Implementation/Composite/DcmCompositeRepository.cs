using Dcm4chee.Persistance.Domain.Models;
using Dcm4chee.Repository.Conditions;
using Dcm4chee.Repository.Models;
using Gt.PERSISTANCE;
using GT.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Dcm4chee.Repository.Implementation.Composite
{
    public class DcmCompositeRepository : AbstractRepository
    {
        public DcmCompositeRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }

        public IQueryable<DcmViewModel> Query(StudyConditionFilter s, SeriesConditionFilter se)
        {
            var exp1 = StudyCondition.Get(s);
            var exp2 = SeriesCondition.Get(se);
            return Query(exp1,exp2);
        }

        public IQueryable<DcmViewModel> Query(Expression<Func<Study, bool>> exp1, Expression<Func<Series, bool>> exp2)
        {
            var location = _AbstractWorkspace.Query<Location>();
            var instance = _AbstractWorkspace.Query<Instance>();
            var series = _AbstractWorkspace.Query<Series>(exp2);
            var study = _AbstractWorkspace.Query<Study>(exp1);
            var patient = _AbstractWorkspace.Query<Patient>();
            var patientID = _AbstractWorkspace.Query<PatientId>();
            var personName = _AbstractWorkspace.Query<PersonName>();
            var list = from l in location
                       join i in instance on l.InstanceFk equals i.Pk
                       join s in series on i.SeriesFk equals s.Pk
                       join stdy in study on s.StudyFk equals stdy.Pk
                       join pa in patient on stdy.PatientFk equals pa.Pk
                       join pe in personName on pa.PatNameFk equals pe.Pk
                       select new DcmViewModel
                       {
                           LocationID=l.Pk,
                           InstanseID=i.Pk,
                           SopCuid=i.SopCuid,
                           SeriesID=s.Pk,
                           SeriesCuid=s.SopCuid,
                           StudyID=s.StudyFk,
                           StudyCuid=stdy.StudyIuid,
                           InstanceID=l.InstanceFk,
                           PatientID=pa.Pk,
                           StudyPatientID=stdy.PatientFk,
                           PersonNameID=pe.Pk,
                           StoragePath=l.StoragePath,
                           PatID=pa.PatNameFk,
                           Modality=s.Modality
                       };
            return list;
        }
    }
}
