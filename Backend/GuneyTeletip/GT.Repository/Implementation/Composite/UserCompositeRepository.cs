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
using static GT.Repository.Conditions.RoleCondition;

namespace GT.Repository.Implementation.Composite
{
    public class UserCompositeRepository : AbstractRepository
    {
        public UserCompositeRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }

        public IQueryable<UserViewModel> Query(UserConditionFilter u, RoleConditionFilter r)
        {
            var exp1 = UserLoginCondition.Get(u);
            var exp2 = RoleCondition.Get(r);
            return Query(exp1, exp2);
        }

        public IQueryable<UserViewModel> Query(Expression<Func<UsrUserLogin, bool>> exp1, Expression<Func<UsrRole, bool>> exp2)
        {
            var user = _AbstractWorkspace.Query<UsrUserLogin>(exp1);
            var role = _AbstractWorkspace.Query<UsrRole>(exp2);
            var userRol = _AbstractWorkspace.Query<UsrUserRole>();
            var list = from u in user
                       join ur in userRol on u.Pk equals ur.FkUser
                       join r in role on ur.FkRole equals r.Pk
                       select new UserViewModel
                       {
                           EmailAdress = u.EmailAdress,
                           Name = u.Name,
                           Password = u.Password,
                           Pk = u.Pk,
                           RecordState = u.RecordState,
                           Surname = u.Surname,
                           TimeCreated = u.TimeCreated,
                           TimeModified = u.TimeModified,
                           FkUserCreated = u.FkUserCreated,
                           UserName = u.UserName,
                           FkUserModified = u.FkUserModified,
                           RolID=r.Pk,
                           RolName=r.UsrRoleAd
                       };
            return list;
        }
    }
}
