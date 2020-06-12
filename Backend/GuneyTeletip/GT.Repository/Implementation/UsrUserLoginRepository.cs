using GT.Persistance.Domain.Models;
using MEDLIFE.PERSISTANCE;
using MEDLIFE.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT.Repository.Implementation
{
    public class UsrUserLoginRepository : AbstractTableRepository<UsrUserLogin>
    {
        public UsrUserLoginRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }

        public override UsrUserLogin GetByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
