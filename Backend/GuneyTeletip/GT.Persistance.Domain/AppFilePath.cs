using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain
{
    public partial class AppFilePath
    {
        public long Pk { get; set; }
        public string Filename { get; set; }
        public DateTime? TimeCreated { get; set; }
        public DateTime? TimeModified { get; set; }
        public DateTime? TimeDeleted { get; set; }
        public long? FkUserCreated { get; set; }
        public long? FkUserModified { get; set; }
    }
}
