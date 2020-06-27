using Gt.PERSISTANCE;
using GT.Persistance.Domain.Models;
using GT.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT.Repository.Implementation
{
    public class RolePermissionRepository : AbstractTableRepository<AppRolePermission>
    {
        public RolePermissionRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }

        public override AppRolePermission GetByID(long id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<AppRolePermission> GetByRoleID(long id)
        {
            return Query(o => o.FkRoleId == id);
        }
    }
}
