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
   
    public class TenatCompositeRepository : AbstractRepository
    {

        public TenatCompositeRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }

        public IQueryable<string> Query(long tenantID)
        {
            var tenantdata = _AbstractWorkspace.Query<UsrTenant>(o => o.Pk == tenantID);
            var tenantskrsdata = _AbstractWorkspace.Query<UsrTenantSkrs>();
       
            var list = from t in tenantdata
                       join s in tenantskrsdata on t.Pk  equals s.FkTenant
                        select new
                        {
                           s.AccessionNoPrefix
                        };
            return null;
        }
    }
}
