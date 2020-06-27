using DBLayerIzcilikYonetimi.Moduller.IzciYonetimi;
using GT.Persistance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GT.Repository.Conditions
{
    public class GetorderStatusConditionFilter
    {
        public string[] AccessionNumberList { get; set; }
        public string Medulainstitutionid { get; set; }
    }
    public class GetorderStatusCondition
    {
        public static Expression<Func<StmGetorderStatusforAccessionnumberlist, bool>> Get(GetorderStatusConditionFilter filter)
        {
            var exp = PredicateBuilder.True<StmGetorderStatusforAccessionnumberlist>();
            if (!string.IsNullOrEmpty(filter.Medulainstitutionid))
            {
                exp = exp.And(o => o.Medulainstitutionid.Contains(filter.Medulainstitutionid));
            }
            if (filter.AccessionNumberList != null && filter.AccessionNumberList.Length > 0)
            {
                var arr = filter.AccessionNumberList.ToList();
                exp = exp.And(o => arr.Contains(o.Accessionnumber));
            }
            return exp;
        }
    }
}
