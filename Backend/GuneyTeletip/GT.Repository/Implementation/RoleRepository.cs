using Gt.PERSISTANCE;
using GT.Persistance.Domain.Models;
using GT.Repository.Conditions;
using GT.Repository.Models.View;
using GT.REPOSITORY;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
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

        public override UsrRole GetByID(long id)
        {
            return Single(o => o.Pk == id);
        }

        public IQueryable<RoleViewModel> Query(RolConditionFilter r)
        {
            var exp = RolCondition.Get(r);
            return Query(exp);
        }

        private IQueryable<RoleViewModel> Query(Expression<Func<UsrRole, bool>> exp)
        {
            var rol = _AbstractWorkspace.Query<UsrRole>(exp);
            var list = from r in rol
                       select new RoleViewModel
                       {
                           RoleID=r.Pk,
                           RoleName=r.Name
                       };
            return list;
        }

        
    }
}
