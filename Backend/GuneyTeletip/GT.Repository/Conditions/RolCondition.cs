using DBLayerIzcilikYonetimi.Moduller.IzciYonetimi;
using GT.Persistance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GT.Repository.Conditions
{
    public class RolConditionFilter
    {
        public long? ID { get; set; }
        public long[] IDList { get; set; }
        public string RolName { get; set; }
    }
    public class RolCondition
    {
        public static Expression<Func<UsrRole, bool>> Get(RolConditionFilter filter)
        {
            var exp = PredicateBuilder.True<UsrRole>();
            if (!string.IsNullOrEmpty(filter.RolName))
            {
                exp = exp.And(o => o.Name.Contains(filter.RolName));
            }
            if (filter.ID.HasValue)
            {
                exp = exp.And(o => o.Pk == filter.ID.Value);
            }
            if (filter.IDList != null && filter.IDList.Length > 0)
            {
                var arr = filter.IDList.ToList();
                exp = exp.And(o => arr.Contains(o.Pk));
            }
            return exp;
        }
    }
}
