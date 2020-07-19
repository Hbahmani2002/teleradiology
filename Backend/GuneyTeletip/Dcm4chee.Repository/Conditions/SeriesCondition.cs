using DBLayerIzcilikYonetimi.Moduller.IzciYonetimi;
using Dcm4chee.Persistance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Dcm4chee.Repository.Conditions
{
    public class SeriesConditionFilter
    {
        public string[] ModalityList { get; set; }
    }
    public class SeriesCondition
    {
        public static Expression<Func<Series, bool>> Get(SeriesConditionFilter filter)
        {
            var exp = PredicateBuilder.True<Series>();
            if (filter.ModalityList!= null && filter.ModalityList.Count()>0)
            {
                var arr = filter.ModalityList.ToList();
                exp = exp.And(o => arr.Contains(o.Modality));
            }
            return exp;
        }
    }
}
