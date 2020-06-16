using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain.Models
{
    public partial class KosStudy
    {
        public long Pk { get; set; }
        public long FkInfStudy { get; set; }
        public short? KosEnumType { get; set; }
        public DateTime? TimeCreated { get; set; }
        public DateTime? TimeDelete { get; set; }
        public long UserFkCreated { get; set; }
        public long UserFkLastModfiead { get; set; }
    }
}
