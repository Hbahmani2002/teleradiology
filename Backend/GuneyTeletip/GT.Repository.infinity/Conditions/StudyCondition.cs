using DBLayerIzcilikYonetimi.Moduller.IzciYonetimi;
using GT.Persistance.Domain.infinity.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace GT.Repository.infinity.Conditions
{
    public class StudyConditionFilter
    {
        public string PatientID { get; set; }
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }
        public string PatientSex { get; set; }
        public string AccessNo { get; set; }
        public string Modalities { get; set; }
        public string StudyInstanceUID { get; set; }
        public decimal? InstanceCount { get; set; }
    }
    public class StudyCondition
    {
        public static Expression<Func<Study, bool>> Get(StudyConditionFilter filter)
        {
            var exp = PredicateBuilder.True<Study>();
            if (!string.IsNullOrEmpty(filter.PatientID))
            {
                exp = exp.And(o => o.PatientId.Contains(filter.PatientID));
            }
            if (!string.IsNullOrEmpty(filter.PatientName))
            {
                exp = exp.And(o => o.PatientName.Contains(filter.PatientName));
            }
            if (!string.IsNullOrEmpty(filter.PatientSex))
            {
                exp = exp.And(o => o.PatientSex.Contains(filter.PatientSex));
            }
            if (!string.IsNullOrEmpty(filter.AccessNo))
            {
                exp = exp.And(o => o.AccessNo.Contains(filter.AccessNo));
            }
            if (!string.IsNullOrEmpty(filter.Modalities))
            {
                exp = exp.And(o => o.Modalities.Contains(filter.Modalities));
            }
            if (!string.IsNullOrEmpty(filter.StudyInstanceUID))
            {
                exp = exp.And(o => o.StudyInstanceUid.Contains(filter.StudyInstanceUID));
            }
            if (filter.InstanceCount.HasValue)
            {
                exp = exp.And(o => o.InstanceCount == filter.InstanceCount.Value);
            }
            return exp;
        }
    }
}
