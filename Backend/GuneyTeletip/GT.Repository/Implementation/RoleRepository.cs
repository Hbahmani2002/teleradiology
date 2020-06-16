using GT.Persistance.Domain.Models;
using MEDLIFE.PERSISTANCE;
using MEDLIFE.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT.Repository.Implementation
{
    public class RoleRepository : AbstractTableRepository<UsrRole>
    {
        public RoleRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }

        public override UsrRole GetByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
