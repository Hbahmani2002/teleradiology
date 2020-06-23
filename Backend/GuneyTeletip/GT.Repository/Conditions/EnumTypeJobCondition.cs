using DBLayerIzcilikYonetimi.Moduller.IzciYonetimi;
using GT.Persistance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace GT.Repository.Conditions
{
    public class EnumTypeJobConditionFilter
    {
        public string Name { get; set; }
    }
    public class EnumTypeJobCondition
    {
        public static Expression<Func<JobEnumtype, bool>> Get(EnumTypeJobConditionFilter filter)
        {
            var exp = PredicateBuilder.True<JobEnumtype>();
            if (!string.IsNullOrEmpty(filter.Name))
            {
                exp = exp.And(o => o.Name.Contains(filter.Name));
            }
            return exp;
        }
    }
}
