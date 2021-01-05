using DBLayerIzcilikYonetimi.Moduller.IzciYonetimi;
using GT.Persistance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace GT.Repository.Conditions
{
    public class StudyOperationCountCondition
    {
        public class StudyOperationCountConditionFilter
        {
            public bool? MakeKosCount { get; set; }
            public bool? SentKosCount { get; set; }
        }
        public static Expression<Func<StudyOperationCount, bool>> Get(StudyOperationCountConditionFilter filter)
        {
            var exp = PredicateBuilder.True<StudyOperationCount>();
            if (filter.MakeKosCount.HasValue)
            {
                //TODO MakekosErrorTryCount 3
                exp = exp.And(o => o.MakekosErrorTryCount < 50);
            }
            if (filter.SentKosCount.HasValue)
            {
                //TODO SentkosErrorTryCount 3
                exp = exp.And(o => o.SentkosErrorTryCount < 50);
            }
            return exp;
        }
    }
}
