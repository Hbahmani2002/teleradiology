using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain
{
    public partial class AppParameter
    {
        public long Pk { get; set; }
        public DateTime? TimeCreated { get; set; }
        public DateTime? TimeModified { get; set; }
        public long? FkUserCreated { get; set; }
        public long? FkUserModified { get; set; }
        public string Value { get; set; }
        public string Key { get; set; }
    }
}
