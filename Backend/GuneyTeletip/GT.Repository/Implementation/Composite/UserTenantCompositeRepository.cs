using Gt.PERSISTANCE;
using GT.Persistance.Domain.Models;
using GT.Repository.Models.View;
using GT.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GT.Repository.Implementation.Composite
{
    public class UserTenantCompositeRepository : AbstractRepository
    {
        public UserTenantCompositeRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }

        public IEnumerable<TenantViewModel> Query(long userID)
        {
            var userTenant = _AbstractWorkspace.Query<UsrUserTenant>(o => o.FkUser== userID);
            var tenant = _AbstractWorkspace.Query<UsrTenant>();

            var list = from u in userTenant
                       join t in tenant on u.FkTenant equals t.Pk
                       select new TenantViewModel
                       {
                          TenantAd=t.TenantShortName,
                          ID=t.Pk
                       };
            return list;
        }
    }
}
