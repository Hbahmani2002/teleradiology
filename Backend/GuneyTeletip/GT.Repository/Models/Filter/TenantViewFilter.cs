using System;
using System.Collections.Generic;
using System.Text;

namespace GT.Repository.Models.Filter
{
    public class TenantViewFilter
    {
        public long Pk { get; set; }
        public string TenantAd { get; set; }
        public string TenantKisaAd { get; set; }
        public int DaySequence { get; set; }
    }
}
