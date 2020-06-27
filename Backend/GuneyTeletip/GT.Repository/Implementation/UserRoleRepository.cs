using Gt.PERSISTANCE;
using GT.Persistance.Domain.Models;
using GT.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT.Repository.Implementation
{
    public class UserRoleRepository : AbstractTableRepository<UsrUserRole>
    {
        public UserRoleRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }

        public override UsrUserRole GetByID(long id)
        {
            return Single(o => o.Pk == id);
        }

        public UsrUserRole GetByUserID(long id)
        {
            return Single(o => o.FkUser == id);
        }
        public IEnumerable<UsrUserRole> GetRolListByUserID(long id)
        {
            return Query(o => o.FkUser == id);
        }
    }
}
