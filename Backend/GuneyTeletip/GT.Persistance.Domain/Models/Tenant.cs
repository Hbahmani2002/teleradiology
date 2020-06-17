using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain.Models
{
    public partial class Tenant
    {
        public Tenant()
        {
            TenantSkrs = new HashSet<TenantSkrs>();
        }

        public long Pk { get; set; }
        public string TenantAd { get; set; }
        public string TenantKisaAd { get; set; }
        public short? TenantRecordType { get; set; }
        public int? DaySequence { get; set; }
        public DateTime? TimeCreated { get; set; }
        public DateTime? TimeModified { get; set; }
        public long FkUserCreated { get; set; }
        public long FkUserModified { get; set; }

        public virtual ICollection<TenantSkrs> TenantSkrs { get; set; }
    }
}
