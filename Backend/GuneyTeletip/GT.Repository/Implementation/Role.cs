using GT.Persistance.Domain.Models;
using MEDLIFE.PERSISTANCE;
using MEDLIFE.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT.Repository.Implementation
{
    public class Role : AbstractTableRepository<UsrRole>
    {
        public Role(IAbstractWorkspace workspace) : base(workspace)
        {

        }

        public override UsrRole GetByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
