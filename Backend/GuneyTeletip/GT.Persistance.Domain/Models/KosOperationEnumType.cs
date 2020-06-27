using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain.Models
{
    public partial class KosOperationEnumType
    {
        public long Pk { get; set; }
        public string Name { get; set; }
        public DateTime? TimeCreated { get; set; }
        public DateTime? TimeModified { get; set; }
        public long? FkUserCreated { get; set; }
        public long? FkUserModified { get; set; }
    }
}
