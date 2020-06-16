using DBLayerIzcilikYonetimi.Moduller.IzciYonetimi;
using GT.Persistance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace GT.Repository.Conditions
{
    public class TenantConditionFilter
    {
        public string TenantAd { get; set; }
    }
    public class TenatCondition
    {
        public static Expression<Func<Tenat, bool>> Get(TenantConditionFilter filter)
        {
            var exp = PredicateBuilder.True<Tenat>();
            if (!string.IsNullOrEmpty(filter.TenantAd))
            {
                exp = exp.And(o => o.TenatAd.Contains(filter.TenantAd));
            }
            return exp;
        }
    }
}
