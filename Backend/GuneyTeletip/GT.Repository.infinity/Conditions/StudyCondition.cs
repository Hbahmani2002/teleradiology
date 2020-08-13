using DBLayerIzcilikYonetimi.Moduller.IzciYonetimi;
using GT.Persistance.Domain.infinity.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace GT.DataService.infinity.Conditions
{
    public class InfStudyConditionFilter
    {
        public string AccessionNo { get; set; }
        public string PatientID { get; set; }
        public DateTime? CreationStartDate { get; set; }
        public DateTime? CreationEndDate { get; set; }
        public long? InfStudyPkLast { get; set; }
        public DateTime? StudyStartDate { get; set; }

        public string SeriesInfo { get; set; }
    }


    public class InfSerieConditionFilter
    {
  
        public string SeriesInfo { get; set; }
    }
    public class InfStudyCondition
    {
        public static Expression<Func<Study, bool>> Get(InfStudyConditionFilter filter)
        {
            var exp = PredicateBuilder.True<Study>();
            if (!string.IsNullOrEmpty(filter.AccessionNo))
            {
                exp = exp.And(o => o.AccessNo.Contains(filter.AccessionNo));
            }
            if (!string.IsNullOrEmpty(filter.PatientID))
            {
                exp = exp.And(o => o.PatientId.Contains(filter.PatientID));
            }
            if (filter.InfStudyPkLast.HasValue)
            {
                exp = exp.And(o => o.StudyKey > filter.InfStudyPkLast.Value);
            }
            if (filter.CreationStartDate.HasValue)
            {
                exp = exp.And(o => o.StudyDttm >= filter.CreationStartDate.Value);
            }
            if (filter.CreationEndDate.HasValue)
            {
                exp = exp.And(o => o.StudyDttm <= filter.CreationEndDate.Value);
            }
            if (filter.StudyStartDate.HasValue)
            {
               exp = exp.And(o => o.StudyDttm >= filter.StudyStartDate.Value);
            }


            return exp;
        }
    }


    public class InfSeriesCondition
    {
        public static Expression<Func<Series, bool>> Get(InfSerieConditionFilter filter)
        {
            var exp = PredicateBuilder.True<Series>();
            if (!string.IsNullOrEmpty(filter.SeriesInfo))
            {
                exp = exp.And(o => !o.SeriesInfo.Contains(filter.SeriesInfo));
            }

    

            return exp;
        }
    }

}
