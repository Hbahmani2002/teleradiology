using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain
{
    public partial class ConstSkrs
    {
        public ConstSkrs()
        {
            UsrTenantSkrs = new HashSet<UsrTenantSkrs>();
        }

        public long Pk { get; set; }
        public string KurumAd { get; set; }
        public string KurumSkrsKodu { get; set; }
        public string KurumSkrsAdi { get; set; }
        public string KurumMedulaTesisKodu { get; set; }
        public string InstitutionName { get; set; }
        public int? QrSettingId { get; set; }
        public DateTime? TimeCreated { get; set; }
        public DateTime? TimeModified { get; set; }
        public long? FkUserCreated { get; set; }
        public long? FkUserModified { get; set; }

        public virtual ICollection<UsrTenantSkrs> UsrTenantSkrs { get; set; }
    }
}
