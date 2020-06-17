using GT.Persistance.Domain.Models;
using MEDLIFE.PERSISTANCE;
using MEDLIFE.REPOSITORY;
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

        public override UsrUserRole GetByID(int id)
        {
            throw new NotImplementedException();
        }
        public UsrUserRole GetByID(long id)
        {
            return Single(o => o.Pk == id);
        }
        public UsrUserRole GetByUserID(long id)
        {
            return Single(o => o.FkUser == id);
        }
    }
}
