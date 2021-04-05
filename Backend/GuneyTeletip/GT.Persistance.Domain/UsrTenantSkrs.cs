using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain
{
    public partial class UsrTenantSkrs
    {
        public long Pk { get; set; }
        public long FkTenant { get; set; }
        public long FkSkrs { get; set; }
        public string ServerName { get; set; }
        public string AccessionNoPrefix { get; set; }
        public string ServerAetitle { get; set; }
        public string ServerHost { get; set; }
        public string CallingAe { get; set; }
        public int? ServerPort { get; set; }
        public long? RecordStatus { get; set; }
        public DateTime? TimeCreated { get; set; }
        public DateTime? TimeModified { get; set; }
        public long FkUserCreated { get; set; }
        public long FkUserModified { get; set; }

        public virtual ConstSkrs FkSkrsNavigation { get; set; }
        public virtual UsrTenant FkTenantNavigation { get; set; }
    }
}
