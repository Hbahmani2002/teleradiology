using MEDLIFE.UTILS.GRID;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT.Repository.Models.View
{
    public class TenantViewModel
    {
        [DataEntityID]
        public long? Pk { get; set; }
        public string TenantAd { get; set; }
        public string TenantKisaAd { get; set; }
        public int? DaySequence { get; set; }
    }
}
