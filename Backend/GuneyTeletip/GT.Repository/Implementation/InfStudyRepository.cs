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
                       join u in userLogin on s.OracleStudyKey equals u.Pk
                       select new InfStudyViewModel
                       {
                           AccessionNumber=s.AccessionNo,
                           IstemAdi="",
                           HastaNo=s.PatientId,
                           ID=s.Pk,
                           PatientName=s.PatinetNameSurname,
                           Modality=s.Modality,
                           KosStateTag=s.StudyDescription,
                           //KosState=s.
                       };

            return list;
        }
    }
}
