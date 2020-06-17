using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain.Models
{
    public partial class TenantSkrs
    {
        public long Pk { get; set; }
        public long FkTenat { get; set; }
        public long FkSkrs { get; set; }
        public string ServerName { get; set; }
        public string AccessionNoOnek { get; set; }
        public string ServerAetitle { get; set; }
        public string ServerHost { get; set; }
        public string CallingAe { get; set; }
        public int? ServerPort { get; set; }
        public short? RecordState { get; set; }
        public DateTime? TimeCreated { get; set; }
        public DateTime? TimeModified { get; set; }
        public long FkUserCreated { get; set; }
        public long FkUserModified { get; set; }

        public virtual Skrs FkSkrsNavigation { get; set; }
        public virtual Tenant FkTenatNavigation { get; set; }
    }
}
