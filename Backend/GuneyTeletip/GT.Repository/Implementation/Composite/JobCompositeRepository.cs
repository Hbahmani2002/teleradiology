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
    public class JobCompositeRepository : AbstractRepository
    {
        public JobCompositeRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }

        public IQueryable<JobViewmodel> Query(EnumTypeJobConditionFilter e, KosStudyJobConditionFilter k)
        {
            var exp1 = EnumTypeJobCondition.Get(e);
            var exp2 = KosStudyJobCondition.Get(k);
            return Query(exp1, exp2);
        }

        public IQueryable<JobViewmodel> Query(Expression<Func<JobEnumtype, bool>> exp1, Expression<Func<KosStudyJob, bool>> exp2)
        {
            var jobEnum = _AbstractWorkspace.Query<JobEnumtype>(exp1);
            var job= _AbstractWorkspace.Query<KosStudyJob>(exp2);
            var list = from j in job
                       join je in jobEnum on j.FkJobEnumType equals je.Pk
                       select new JobViewmodel
                       {
                           BasariliSayisi=j.SuccessfulCount.Value,
                           BasarisizSayisi=j.ErrorCount.Value,
                           BasTarih=j.TimeCreated.Value,
                           BitTarih=j.TimeStop.Value,
                           Tip=je.Name
                       };
            return list;
        }
    }
}
