using Gt.PERSISTANCE;
using GT.Persistance.Domain.Models;
using GT.Repository.Conditions;
using GT.Repository.Models.View;
using GT.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GT.Repository.Implementation
{
    public class UserLoginRepository : AbstractTableRepository<UsrUserLogin>
    {
        public UserLoginRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }

        public override UsrUserLogin GetByID(int id)
        {
            throw new NotImplementedException();
        }
        public UsrUserLogin GetByID(long id)
        {
            return Single(o => o.Pk == id);
        }
    }
}
