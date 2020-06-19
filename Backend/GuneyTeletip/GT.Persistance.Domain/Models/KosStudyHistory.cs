using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain.Models
{
    public partial class KosStudyHistory
    {
        public long Pk { get; set; }
        public long FkKosStudy { get; set; }
        public string Result { get; set; }
        public int? EnumType { get; set; }
        public DateTime? TimeCreated { get; set; }
        public DateTime? TimeModified { get; set; }
        public long? FkUserCreated { get; set; }
        public uint FkUserModified { get; set; }
    }
}
