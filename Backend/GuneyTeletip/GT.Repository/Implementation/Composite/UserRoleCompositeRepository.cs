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

namespace GT.Repository.Implementation.Composite
{
    public class UserRoleCompositeRepository : AbstractRepository
    {
        public UserRoleCompositeRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }

        public IQueryable<UserRoleViewModel> Query(UserRolConditionFilter u, RolConditionFilter r)
        {
            var exp1 = UserRolCondition.Get(u);
            var exp2 = RolCondition.Get(r);
            return Query(exp1,exp2);
        }
        private IQueryable<UserRoleViewModel> Query(Expression<Func<UsrUserRole, bool>> exp1, Expression<Func<UsrRole, bool>> exp2)
        {
            var role = _AbstractWorkspace.Query<UsrRole>(exp2);
            var userRol = _AbstractWorkspace.Query<UsrUserRole>(exp1);
            var list = from ur in userRol
                       join r in role on ur.FkRole equals r.Pk
                       select new UserRoleViewModel
                       {
                           RoleID = r.Pk,
                           RoleName = r.Name,
                           UserID = ur.FkUser
                       };
            return list;
        }
    }
}
