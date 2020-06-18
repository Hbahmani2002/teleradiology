using GT.UTILS.GRID;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT.Repository.Models.View
{
    public class TenantViewModel
    {
        [DataEntityID]
        public long? ID { get; set; }
        public string TenantAd { get; set; }
    }
}
