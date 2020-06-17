using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain.Models
{
    public partial class AppLog
    {
        public long Pk { get; set; }
        public int? LogType { get; set; }
        public string Desc1 { get; set; }
        public string Desc2 { get; set; }
        public string Desc3 { get; set; }
        public DateTime? TimeCreated { get; set; }
        public DateTime? TimeModified { get; set; }
        public long FkUserCreated { get; set; }
        public long FkUserModified { get; set; }
    }
}
