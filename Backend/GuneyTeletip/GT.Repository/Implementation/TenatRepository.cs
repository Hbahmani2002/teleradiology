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
    public class TenantRepository : AbstractTableRepository<UsrTenant>
    {
        public TenantRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }

        public override UsrTenant GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public UsrTenant GetByID(long id)
        {
            return Single(o => o.Pk == id);
        }

        public IQueryable<TenantViewModel> Query(TenantConditionFilter t)
        {
            var res = TenatCondition.Get(t);

            return Query(res);
        }
        private IQueryable<TenantViewModel> Query(Expression<Func<UsrTenant, bool>> exp)
        {
            var tenant = _AbstractWorkspace.Query<UsrTenant>(exp);
            var list = from t in tenant
                       select new TenantViewModel
                       {
                           //TenantAd=t.TenantAd,
                           //Pk=t.Pk
                       };
            return list;
        }
    }
}
