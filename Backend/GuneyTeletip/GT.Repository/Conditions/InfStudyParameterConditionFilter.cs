using DBLayerIzcilikYonetimi.Moduller.IzciYonetimi;
using GT.Persistance.Domain.Models;
using System;
using System.Linq.Expressions;

namespace GT.Repository.Implementation
{
    public class InfStudyParameterConditionFilter
    {
        public int? RecordState { get; set; }        
    }
    public class InfStudyParameterCondition
    {
        public static Expression<Func<InfStudyParameter, bool>> Get(InfStudyParameterConditionFilter filter)
        {
            var exp = PredicateBuilder.True<InfStudyParameter>();
            if (filter.RecordState.HasValue)
            {
                exp = exp.And(o => o.RecordType==filter.RecordState.Value);
            }
            return exp;
        }
    }
}