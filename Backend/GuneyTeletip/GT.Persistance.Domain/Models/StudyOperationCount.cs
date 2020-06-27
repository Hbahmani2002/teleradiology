using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain.Models
{
    public partial class StudyOperationCount
    {
        public long Pk { get; set; }
        public long? FkStudy { get; set; }
        public long? FkOperationEnumType { get; set; }
        public long? ErrorTryCount { get; set; }
        public DateTime? TimeCreated { get; set; }
        public DateTime? TimeModified { get; set; }
        public long? FkUserCreated { get; set; }
        public long? FkUserModified { get; set; }
    }
}
