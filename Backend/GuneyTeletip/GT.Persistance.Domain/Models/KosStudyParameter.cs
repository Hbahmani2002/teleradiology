using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain.Models
{
    public partial class KosStudyParameter
    {
        public long Pk { get; set; }
        public DateTime? TimeStart { get; set; }
        public DateTime? TimeStop { get; set; }
        public long? OracleStudyKeyLast { get; set; }
        public long? RecordStatus { get; set; }
        public DateTime? TimeCreated { get; set; }
        public DateTime? TimeModified { get; set; }
        public long? FkUserCreated { get; set; }
        public long? FkUserModified { get; set; }
        public long? FkTenant { get; set; }
        public string Name { get; set; }
        public int? IntervalMinute { get; set; }
    }
}
