using GT.Persistance.Domain.Models;
using GT.Repository.Conditions;
using GT.Repository.Models.View;
using MEDLIFE.PERSISTANCE;
using MEDLIFE.REPOSITORY;
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


        public List<InfStudyViewModel> Query(InfStudyConditionFilter filter)
        {
            var exp = InfStudyCondition.Get(filter);
            return Query(exp);
        }

        public IQueryable<InfStudyViewModel> QueryGrid(InfStudyConditionFilter filter)
        {
            var exp = InfStudyCondition.Get(filter);
            return QueryGrid(exp);
        }
        public List<InfStudyViewModel> Query(Expression<Func<InfStudy, bool>> exp)
        {

            var userLogin = _AbstractWorkspace.Query<UsrUserLogin>();
            var infStudiesLogin  = _AbstractWorkspace.Query<InfStudy>(exp);
            var list = from s in infStudiesLogin
                       join u in userLogin on s.UserFk equals u.Pk
                       select new InfStudyViewModel
                       {

                           Modality = s.Modality,
                           Accession_no = s.AccessionNo,
                           Patinet_id = s.PatientId,
                           Patine_name = s.PatinetNameSurname,
                           Pk = s.Pk

                       };

            return list.ToList();
        }
        public IQueryable<InfStudyViewModel> QueryGrid(Expression<Func<InfStudy, bool>> exp)
        {

            var userLogin = _AbstractWorkspace.Query<UsrUserLogin>();
            var infStudiesLogin = _AbstractWorkspace.Query<InfStudy>(exp);
            var list = from s in infStudiesLogin
                       join u in userLogin on s.UserFk equals u.Pk
                       select new InfStudyViewModel
                       {

                           Modality = s.Modality,
                           Accession_no = s.AccessionNo,
                           Patinet_id = s.PatientId,
                           Patine_name = s.PatinetNameSurname,
                           Pk = s.Pk

                       };

            return list;
        }


    }



}
