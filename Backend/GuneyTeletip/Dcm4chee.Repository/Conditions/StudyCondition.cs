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
        public string BasTar { get; set; }
        public string BitTar { get; set; }
        public long? ID { get; set; }
    }
    public class StudyCondition
    {
        public static Expression<Func<Study, bool>> Get(StudyConditionFilter filter)
        {
            var exp = PredicateBuilder.True<Study>();
            if (filter.AccessionNo.HasValue)
            {
                exp = exp.And(o => o.Pk==filter.ID);
            }
            if (filter.AccessionNo.HasValue)
            {
                exp = exp.And(o => o.AccessionNo.Length > filter.AccessionNo);
            }
            if (!string.IsNullOrEmpty(filter.BasTar))
            {
                exp = exp.And(o => o.StudyDate.Contains(filter.BasTar));
            }
            //if (!string.IsNullOrEmpty(filter.BitTar))
            //{
            //    exp = exp.And(o => o.StudyDate.Contains(filter.BitTar));
            //}

   
            exp = exp.And(o => o.AccessionNo != "*");

            return exp;
        }
    }
}
