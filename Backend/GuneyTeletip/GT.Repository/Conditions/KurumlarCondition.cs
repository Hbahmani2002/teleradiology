using DBLayerIzcilikYonetimi.Moduller.IzciYonetimi;
using GT.Persistance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GT.Repository.Conditions
{
    public class KurumlarConditionFilter
    {
        public string KurumAd { get; set; }

        public string KurumOnEk { get; set; }
        public long[] KurumlarIDList { get; set; }
    }
    public class KurumCondition
    {
        public static Expression<Func<UsrTenant, bool>> Get(KurumlarConditionFilter filter)
        {
            var exp = PredicateBuilder.True<UsrTenant>();
            if (!string.IsNullOrEmpty(filter.KurumAd))
            {
                exp = exp.And(o => o.Name.Contains(filter.KurumAd));
            }
            if(filter.KurumlarIDList != null && filter.KurumlarIDList.Count() > 0)
            {
                var arr = filter.KurumlarIDList.ToList();
                exp = exp.And(o => arr.Contains(o.Pk));
            }
            return exp;
        }
    }
}
