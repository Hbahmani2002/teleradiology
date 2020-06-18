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

    public class TenantCompositeRepository : AbstractRepository
    {

        public TenantCompositeRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }

        public IQueryable<TenantSkrsCompositeViewModel> Query()
        {
            var tenantdata = _AbstractWorkspace.Query<Tenant>();
            var tenantskrsdata = _AbstractWorkspace.Query<TenantSkrs>();

            var query = from t in tenantdata
                        join s in tenantskrsdata on t.Pk equals s.FkTenat
                        select new TenantSkrsCompositeViewModel
                        {
                            ID = t.Pk,
                            AccessionNoOnek = s.AccessionNoOnek
                        };
            return query;
        }
        public TenantSkrsCompositeViewModel Single(long tenantID)
        {
            return Query()
                .SingleOrDefault(o => o.ID == tenantID);
        }
    }
}
