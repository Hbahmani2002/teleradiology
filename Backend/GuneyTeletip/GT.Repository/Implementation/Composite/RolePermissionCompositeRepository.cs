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
    public class RolePermissionCompositeRepository : AbstractRepository
    {
        public RolePermissionCompositeRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }
        public IQueryable<PermissionViewModel> Query(RolConditionFilter r)
        {
            var exp1 = RolCondition.Get(r);
            return Query(exp1);
        }

        public IQueryable<PermissionViewModel> Query(Expression<Func<UsrRole, bool>> exp)
        {
            var role = _AbstractWorkspace.Query<UsrRole>(exp);
            var permission = _AbstractWorkspace.Query<AppPermissionName>();
            var rolePermission = _AbstractWorkspace.Query<AppRolePermission>();
            var list = from r in role
                       join rp in rolePermission on r.Pk equals rp.FkRoleId
                       join p in permission on rp.FkPermissionId equals p.Pk
                       select new PermissionViewModel
                       {
                           PermissionID = p.Pk,
                           PermissionName = p.Name
                       };
            return list;
        }
    }
}
