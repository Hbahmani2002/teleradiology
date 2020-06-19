using Gt.PERSISTANCE;
using GT.Persistance.Domain.Models;
using GT.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GT.Repository.Implementation
{
    public class UserTenantRepository : AbstractTableRepository<UsrUserTenant>
    {
        public UserTenantRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }

        public override UsrUserTenant GetByID(int id)
        {
            throw new NotImplementedException();
        }
        public IQueryable<UsrUserTenant> GetTenantIDByUserID(long userID)
        {
            return Query(o => o.FkUser == userID);
        }
    }
}
