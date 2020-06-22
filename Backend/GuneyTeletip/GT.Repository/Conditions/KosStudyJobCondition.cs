using DBLayerIzcilikYonetimi.Moduller.IzciYonetimi;
using GT.Persistance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GT.Repository.Conditions
{
    public class KosStudyJobConditionFilter
    {
        public long? ID { get; set; }
        public long[] IDList { get; set; }
        public DateTime? TimeStart { get; set; }
        public DateTime? TimeStop { get; set; }
        public long? SuccessfulCount { get; set; }
        public long? ErrorCount { get; set; }
    }
    public class KosStudyJobCondition
    {
        public static Expression<Func<KosStudyJob, bool>> Get(KosStudyJobConditionFilter filter)
        {
            var exp = PredicateBuilder.True<KosStudyJob>();
            if (filter.ID.HasValue)
            {
                exp = exp.And(o => o.Pk == filter.ID.Value);
            }
            if (filter.IDList != null && filter.IDList.Length > 0)
            {
                var arr = filter.IDList.ToList();
                exp = exp.And(o => arr.Contains(o.Pk));
            }
            if (filter.TimeStart.HasValue)
            {
                exp = exp.And(o => o.TimeStart == filter.TimeStart.Value);
            }
            if (filter.TimeStop.HasValue)
            {
                exp = exp.And(o => o.TimeStop == filter.TimeStop.Value);
            }
            if (filter.SuccessfulCount.HasValue)
            {
                exp = exp.And(o => o.SuccessfulCount == filter.SuccessfulCount.Value);
            }
            if (filter.ErrorCount.HasValue)
            {
                exp = exp.And(o => o.ErrorCount == filter.ErrorCount.Value);
            }
            return exp;
        }
    }
}
