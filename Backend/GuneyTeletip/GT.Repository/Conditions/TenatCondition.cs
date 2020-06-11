using DBLayerIzcilikYonetimi.Moduller.IzciYonetimi;
using GT.Persistance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace GT.Repository.Conditions
{
    public class TenatConditionFilter
    {
        public string TenatAd { get; set; }
    }
    public class TenatCondition
    {
        public static Expression<Func<Tenat, bool>> Get(TenatConditionFilter filter)
        {
            var exp = PredicateBuilder.True<Tenat>();
            if (!string.IsNullOrEmpty(filter.TenatAd))
            {
                exp = exp.And(o => o.TenatAd.Contains(filter.TenatAd));
            }
            return exp;
        }
    }
}
