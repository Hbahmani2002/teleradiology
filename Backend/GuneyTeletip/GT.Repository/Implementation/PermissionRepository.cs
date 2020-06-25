using Gt.PERSISTANCE;
using GT.Persistance.Domain.Models;
using GT.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT.Repository.Implementation
{
    public class PermissionRepository : AbstractTableRepository<AppPermissionName>
    {
        public PermissionRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }

        public override AppPermissionName GetByID(long id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<AppPermissionName> GetByRoleID(long id)
        {
            return null;//Query(o => o.)
        }
    }
}
