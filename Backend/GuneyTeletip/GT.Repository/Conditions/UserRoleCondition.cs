using DBLayerIzcilikYonetimi.Moduller.IzciYonetimi;
using GT.Persistance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace GT.Repository.Conditions
{
    public class RoleCondition
    {
        public class RoleConditionFilter
        {
            public string RoleName { get; set; }
        }
        public static Expression<Func<UsrRole, bool>> Get(RoleConditionFilter filter)
        {
            var exp = PredicateBuilder.True<UsrRole>();
            if (!string.IsNullOrEmpty(filter.RoleName))
            {
                exp = exp.And(o => o.UsrRoleAd.Contains(filter.RoleName));
            }
            return exp;
        }
    }
}
