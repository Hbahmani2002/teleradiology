using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain.Models
{
    public partial class KosStudyJob
    {
        public long Pk { get; set; }
        public DateTime? TimeStart { get; set; }
        public DateTime? TimeStop { get; set; }
        public long? FkJobEnumType { get; set; }
        public long? SuccessfulCount { get; set; }
        public long? ErrorCount { get; set; }
        public DateTime? TimeCreated { get; set; }
        public DateTime? TimeModified { get; set; }
        public long? FkUserCreated { get; set; }
        public long? FkUserModified { get; set; }
        public long? RecordStatus { get; set; }
    }
}
