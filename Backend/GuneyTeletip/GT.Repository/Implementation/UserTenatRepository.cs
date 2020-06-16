using GT.Persistance.Domain.Models;
using MEDLIFE.PERSISTANCE;
using MEDLIFE.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT.Repository.Implementation
{
    public class UserTenatRepository : AbstractTableRepository<UsrUserTenat>
    {
        public UserTenatRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }

        public override UsrUserTenat GetByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
