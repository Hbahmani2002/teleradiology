using GT.UTILS.GRID;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT.Repository.Models.View
{
    public class TenantViewModel:BaseTableViewModel
    {
        [DataEntityID]
        public long? ID { get; set; }
        public string TenantAd { get; set; }
    }


    public class KurumViewModel : BaseTableViewModel
    {
        [DataEntityID]
        public string KurumAd { get; set; }
        public string KurumOnEk { get; set; }
    }

}
