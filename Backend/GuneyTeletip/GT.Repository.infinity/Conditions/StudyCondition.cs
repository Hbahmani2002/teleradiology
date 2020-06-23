﻿using DBLayerIzcilikYonetimi.Moduller.IzciYonetimi;
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
        public DateTime? CreationStartDate { get; set; }
        public long? InfStudyPkLast { get; set; }

        public DateTime? StudyStartDate { get; set; }
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
            if (filter.InfStudyPkLast.HasValue)
            {
                exp = exp.And(o => o.StudyKey >= filter.InfStudyPkLast.Value);

            }
            if (filter.CreationStartDate.HasValue)
            {
                exp = exp.And(o => o.CreationDttm >= filter.CreationStartDate.Value);


            }
            if (filter.StudyStartDate.HasValue)
            {
                exp = exp.And(o => o.StudyDttm >= filter.StudyStartDate.Value);
            }
      



            return exp;
        }
    }

}
