using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain.Models
{
    public partial class InfStudyParameter
    {
        public long Pk { get; set; }
        public DateTime? InfCreationStartDate { get; set; }
        public DateTime? InfCreationStopDate { get; set; }
        public long InfStudyPkLast { get; set; }
        public short RecordType { get; set; }
        public DateTime? TimeCreated { get; set; }
        public DateTime? TimeDelete { get; set; }
        public long UserFk { get; set; }
        public long UserFkLastModfiead { get; set; }
        public long TenatFk { get; set; }
    }
}
