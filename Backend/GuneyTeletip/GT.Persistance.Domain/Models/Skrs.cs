﻿using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain.Models
{
    public partial class Skrs
    {
        public Skrs()
        {
            TenantSkrs = new HashSet<TenantSkrs>();
        }

        public long Pk { get; set; }
        public string KurumAd { get; set; }
        public string KurumSkrsKodu { get; set; }
        public string KurumSkrsAdi { get; set; }
        public string KurumMedulaTesisKodu { get; set; }
        public string InstitutionName { get; set; }
        public int QrSettingId { get; set; }
        public DateTime? TimeCreated { get; set; }
        public DateTime? TimeModified { get; set; }
        public long FkUserCreated { get; set; }
        public long FkUserModified { get; set; }

        public virtual ICollection<TenantSkrs> TenantSkrs { get; set; }
    }
}
