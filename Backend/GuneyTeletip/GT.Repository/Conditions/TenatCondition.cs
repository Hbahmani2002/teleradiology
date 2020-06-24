using DBLayerIzcilikYonetimi.Moduller.IzciYonetimi;
using GT.Persistance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GT.Repository.Conditions
{
    public class TenantConditionFilter
    {
        public string TenantAd { get; set; }
        public long[] TenantIDList { get; set; }
    }
    public class TenatCondition
    {
        public static Expression<Func<UsrTenant, bool>> Get(TenantConditionFilter filter)
        {
            var exp = PredicateBuilder.True<UsrTenant>();
            if (!string.IsNullOrEmpty(filter.TenantAd))
            {
                exp = exp.And(o => o.Name.Contains(filter.TenantAd));
            }
            if(filter.TenantIDList!=null && filter.TenantIDList.Count() > 0)
            {
                var arr = filter.TenantIDList.ToList();
                exp = exp.And(o => arr.Contains(o.Pk));
            }
            return exp;
        }
    }
}
