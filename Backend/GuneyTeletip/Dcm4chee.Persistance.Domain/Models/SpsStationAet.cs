using System;
using System.Collections.Generic;

namespace Dcm4chee.Persistance.Domain.Models
{
    public partial class SpsStationAet
    {
        public long MwlItemFk { get; set; }
        public string StationAet { get; set; }

        public virtual MwlItem MwlItemFkNavigation { get; set; }
    }
}
