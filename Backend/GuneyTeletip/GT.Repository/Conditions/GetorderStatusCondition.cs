using DBLayerIzcilikYonetimi.Moduller.IzciYonetimi;
using GT.Persistance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GT.Repository.Conditions
{
    public class GetorderStatusConditionFilter
    {
        public string AccessionNumber { get; set; }
        public string Medulainstitutionid { get; set; }
        public DateTime? BasTar { get; set; }
        public DateTime? BitTar { get; set; }
        public long[] HastaneIDList { get; set; }
        public long[] TeletipStatusIDList { get; set; }
    }
    public class GetorderStatusCondition
    {
        public static Expression<Func<StmGetorderStatusforAccessionnumberlist, bool>> Get(GetorderStatusConditionFilter filter)
        {
            var exp = PredicateBuilder.True<StmGetorderStatusforAccessionnumberlist>();
            if (!string.IsNullOrEmpty(filter.Medulainstitutionid))
            {
                exp = exp.And(o => o.Medulainstitutionid.Contains(filter.Medulainstitutionid));
            }
            if (!string.IsNullOrEmpty(filter.AccessionNumber))
            {
                exp = exp.And(o => o.Accessionnumber.Contains(filter.AccessionNumber));
            }
            if (filter.BasTar.HasValue)
            {
                exp = exp.And(o => o.TimeCreated>=filter.BasTar);
            }
            if (filter.BitTar.HasValue)
            {
                exp = exp.And(o => o.TimeCreated <= filter.BitTar);
            }
            if(filter.HastaneIDList!=null && filter.HastaneIDList.Count() > 0)
            {
                exp = exp.And(o => o.FkTenant.ToString().Contains(filter.HastaneIDList.ToString()));
            }
            if (filter.TeletipStatusIDList != null && filter.TeletipStatusIDList.Count() > 0)
            {
                exp = exp.And(o => o.Teletipstatusid.ToString().Contains(filter.TeletipStatusIDList.ToString()));
            }
            return exp;
        }
    }
}
