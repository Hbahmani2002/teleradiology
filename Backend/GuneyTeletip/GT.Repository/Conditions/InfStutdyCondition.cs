using DBLayerIzcilikYonetimi.Moduller.IzciYonetimi;
using GT.Persistance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace GT.Repository.Conditions
{
    public class InfStudyConditionFilter
    {
        public string Modality { get; set; }
        public string Patine_name { get; set; }
        public string Accession_no { get; set; }
        public string Patinet_id { get; set; }
        public long? Pk { get; set; }
        public long InfFkStudy { get; set; }
    }
    public class InfStudyCondition
    {
        public static Expression<Func<InfStudy , bool>> Get(InfStudyConditionFilter filter)
        {
            var exp = PredicateBuilder.True<InfStudy>();
            if (!string.IsNullOrEmpty(filter.Modality))
            {
                exp = exp.And(o => o.Modality.Contains(filter.Modality));
            }     
            if (!string.IsNullOrEmpty(filter.Patine_name))
            {
                exp = exp.And(o => o.PatinetNameSurname.Contains(filter.Patine_name));
            }
            if (!string.IsNullOrEmpty(filter.Accession_no))
            {
                exp = exp.And(o => o.AccessionNo.Contains(filter.Accession_no));
            }
            if (!string.IsNullOrEmpty(filter.Patinet_id))
            {
                exp = exp.And(o => o.PatientId.Contains(filter.Patinet_id));
            }

            if (filter.Pk.HasValue)
            {
                exp = exp.And(o => o.Pk == filter.Pk.Value);
            }
            return exp;
        }
    }
}
