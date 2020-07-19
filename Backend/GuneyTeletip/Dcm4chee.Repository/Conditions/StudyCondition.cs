using DBLayerIzcilikYonetimi.Moduller.IzciYonetimi;
using Dcm4chee.Persistance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Dcm4chee.Repository.Conditions
{
    public class StudyConditionFilter
    {
        public long? AccessionNo { get; set; }
        public DateTime? BasTar { get; set; }
        public DateTime? BitTar { get; set; }
    }
    public class StudyCondition
    {
        public static Expression<Func<Study, bool>> Get(StudyConditionFilter filter)
        {
            var exp = PredicateBuilder.True<Study>();
            if (filter.AccessionNo.HasValue)
            {
                exp = exp.And(o => o.AccessionNo.Length > filter.AccessionNo);
            }
            if (filter.BasTar.HasValue)
            {
                exp = exp.And(o => DateTime.Parse(o.StudyDate)>=filter.BasTar);
            }
            if (filter.BitTar.HasValue)
            {
                exp = exp.And(o => DateTime.Parse(o.StudyDate) <= filter.BitTar);
            }
            return exp;
        }
    }
}
