using GT.Persistance.Domain.Models;
using GT.Repository.Conditions;
using GT.Repository.Models.View;
using MEDLIFE.PERSISTANCE;
using MEDLIFE.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        public IQueryable<RolViewModel> Query(RolConditionFilter r)
        {
            var exp = RolCondition.Get(r);
            return Query(exp);
        }

        private IQueryable<RolViewModel> Query(Expression<Func<UsrRole, bool>> exp)
        {
            var rol = _AbstractWorkspace.Query<UsrRole>(exp);
            var list = from r in rol
                       select new RolViewModel
                       {
                           RoleID=r.Pk,
                           RoleName=r.UsrRoleAd
                       };
            return list;
        }

        
    }
}
