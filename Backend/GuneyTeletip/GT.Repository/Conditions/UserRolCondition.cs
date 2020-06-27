using DBLayerIzcilikYonetimi.Moduller.IzciYonetimi;
using GT.Persistance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GT.Repository.Conditions
{
    public class UserRolConditionFilter
    {
        public long? UserID { get; set; }
        public long[] UserIDList { get; set; }
    }
    public class UserRolCondition
    {
        public static Expression<Func<UsrUserRole, bool>> Get(UserRolConditionFilter filter)
        {
            var exp = PredicateBuilder.True<UsrUserRole>();
            if (filter.UserID.HasValue)
            {
                exp = exp.And(o => o.FkUser == filter.UserID.Value);
            }
            if (filter.UserIDList!=null && filter.UserIDList.Count()>0)
            {
                exp = exp.And(o => o.FkUser.ToString().Contains(filter.UserIDList.ToString()));
            }
            return exp;
        }
    }
}
