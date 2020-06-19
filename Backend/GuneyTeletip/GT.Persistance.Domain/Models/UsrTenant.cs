using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain.Models
{
    public partial class UsrTenant
    {
        public UsrTenant()
        {
            UsrTenantSkrs = new HashSet<UsrTenantSkrs>();
        }

        public long Pk { get; set; }
        public string Name { get; set; }
        public string TenantShortName { get; set; }
        public short? RecordStatus { get; set; }
        public DateTime? TimeCreated { get; set; }
        public DateTime? TimeModified { get; set; }
        public long? FkUserCreated { get; set; }
        public long? FkUserModified { get; set; }

        public virtual ICollection<UsrTenantSkrs> UsrTenantSkrs { get; set; }
    }
}
