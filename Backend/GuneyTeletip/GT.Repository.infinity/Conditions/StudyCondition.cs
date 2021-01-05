using DBLayerIzcilikYonetimi.Moduller.IzciYonetimi;
using GT.Persistance.Domain.infinity.Models;
using System;
using System.Collections;
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
        public string Source_Aetitle { get; set; }
        
        public string [] Acc { get; set; }

    }


    public class InfSerieConditionFilter
    {
  
        public string SeriesInfo { get; set; }

    }

    public class InfManuelKeyConditionFilter
    {

        public long Key { get; set; }
        public string SeriesInfo { get; set; }
        public string VolumeCode { get; set; }
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

            if (filter.StudyStartDate.HasValue)
            {
                exp = exp.And(o => o.StudyDttm >= filter.StudyStartDate.Value);
            }


            if (!string.IsNullOrEmpty(filter.Source_Aetitle))
            {
                exp = exp.And(o => !o.SourceAetitle.Contains(filter.Source_Aetitle));
            }

            if (!string.IsNullOrEmpty(filter.Source_Aetitle))
            {
                exp = exp.And(o => !o.SourceAetitle.Contains(filter.Source_Aetitle));
            }

            if (filter.Acc != null && filter.Acc.Length > 0)
            {
                var list = new List<string>();
                foreach (var n in filter.Acc)
                {
                    list.Add(n);
                }
                var listString = list;
                exp = exp.And(o => listString.Contains(o.AccessNo));

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
    public class InfSeriesKeyCondition
    {
        public static Expression<Func<Series, bool>> Get(InfManuelKeyConditionFilter filter, long hangiVeri)
        {
           
            var exp = PredicateBuilder.True<Series>();
            
            if (!string.IsNullOrEmpty(filter.SeriesInfo))
            {
                exp = exp.And(o => !o.SeriesInfo.Contains(filter.SeriesInfo));
            }

            exp = exp.And(o => o.StudyKey == filter.Key);
        
            return exp;
        }

        public static Expression<Func<Instance, bool>> GetInstance(InfManuelKeyConditionFilter filter, long hangiVeri)
        {

            var exp = PredicateBuilder.True<Instance>();

            exp = exp.And(o => o.SeriesKey == filter.Key);
            return exp;
        }
        public static Expression<Func<Instanceloc, bool>> GetInstanceLoc(InfManuelKeyConditionFilter filter, long hangiVeri)
        {

            var exp = PredicateBuilder.True<Instanceloc>();

            exp = exp.And(o => o.InstanceKey == filter.Key);
            return exp;
        }


        public static Expression<Func<Volume, bool>> GetVolume(InfManuelKeyConditionFilter filter, long hangiVeri)
        {

            var exp = PredicateBuilder.True<Volume>();

            exp = exp.And(o => o.VolumeCode == filter.VolumeCode);
            return exp;
        }

    }
}
