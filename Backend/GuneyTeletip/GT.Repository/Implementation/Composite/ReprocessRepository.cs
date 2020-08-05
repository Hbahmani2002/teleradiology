using Gt.PERSISTANCE;
using GT.Persistance.Domain.Models;
using GT.Repository.Conditions;
using GT.Repository.Models.View.Composite;
using GT.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GT.Repository.Implementation.Composite
{
    public class ReprocessRepository : AbstractRepository
    {
        public ReprocessRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }

        public IQueryable<ReprocessViewModel> Query(InfStudyConditionFilter s)
        {
            var exp1 = InfStudyCondition.Get(s,10);
            return Query(exp1);
        }

        public IQueryable<ReprocessViewModel> Query(Expression<Func<KosStudy, bool>> exp)
        {
            var study = _AbstractWorkspace.Query<KosStudy>(exp);
            var getorderStatus = _AbstractWorkspace.Query<StmGetorderStatusforAccessionnumberlist>();
            var query = from s in study
                        join g in getorderStatus on s.Pk equals g.FkKosStudy
                        select new ReprocessViewModel
                        {
                            AccessionNumber=s.AccessionNo,
                            MedulaInstitutionID=g.Medulainstitutionid,
                            StudyID=s.Pk
                        };
            return query;
        }
    }
}
