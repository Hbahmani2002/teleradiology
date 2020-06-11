using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain.Models
{
    public partial class Skrs
    {
        public Skrs()
        {
            TenatSkrs = new HashSet<TenatSkrs>();
        }

        public long Pk { get; set; }
        public string KurumAd { get; set; }
        public string KurumSkrsKodu { get; set; }
        public string KurumSkrsAdi { get; set; }
        public string KurumMedulaTesisKodu { get; set; }
        public string KurumSettingId { get; set; }
        public DateTime? TimeCreated { get; set; }
        public DateTime? TimeDelete { get; set; }
        public long UserFk { get; set; }
        public long UserFkLastModfiead { get; set; }

        public virtual ICollection<TenatSkrs> TenatSkrs { get; set; }
    }
}
