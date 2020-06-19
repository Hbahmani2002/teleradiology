using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain.Models
{
    public partial class UsrUserTenant
    {
        public long Pk { get; set; }
        public long FkUser { get; set; }
        public DateTime? TimeCreated { get; set; }
        public DateTime? TimeModifiel { get; set; }
        public long FkUserCreated { get; set; }
        public long FkUserModified { get; set; }
        public long FkTenant { get; set; }
    }
}
