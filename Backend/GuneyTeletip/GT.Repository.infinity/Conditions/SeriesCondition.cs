using DBLayerIzcilikYonetimi.Moduller.IzciYonetimi;
using GT.Persistance.Domain.infinity.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace GT.Repository.infinity.Conditions
{
    public class SeriesConditionFilter
    {
        public string SeriesInfo { get; set; }


        public long? StudyKey { get; set; }
    }
    public class SeriesCondition
    {
        public static Expression<Func<Series, bool>> Get(SeriesConditionFilter filter)
        {
            var exp = PredicateBuilder.True<Series>();
            if (!string.IsNullOrEmpty(filter.SeriesInfo))
            {
                exp = exp.And(o => !o.SeriesInfo.Contains(filter.SeriesInfo));
            }
  
            if (filter.StudyKey.HasValue)
            {
                exp = exp.And(o => o.StudyKey == filter.StudyKey.Value);
            }


            return exp;
        }

    }
}
