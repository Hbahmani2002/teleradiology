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
    public class TenatRepository : AbstractTableRepository<Tenant>
    {
        public TenatRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }

        public override Tenant GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Tenant GetByID(long id)
        {
            return Single(o => o.Pk == id);
        }

        public IQueryable<TenantViewModel> Query(TenantConditionFilter t)
        {
            var res = TenatCondition.Get(t);

            return Query(res);
        }
        private IQueryable<TenantViewModel> Query(Expression<Func<Tenant, bool>> exp)
        {
            var tenant = _AbstractWorkspace.Query<Tenant>(exp);
            var list = from t in tenant
                       select new TenantViewModel
                       {
                           TenantAd=t.TenantAd
                       };
            return list;
        }
    }
}
