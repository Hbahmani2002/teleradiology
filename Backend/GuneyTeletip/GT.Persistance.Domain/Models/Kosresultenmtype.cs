using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain.Models
{
    public partial class KosResultEnmtype
    {
        public long Pk { get; set; }
        public int EnmId { get; set; }
        public string EnmAd { get; set; }
        public DateTime? TimeCreated { get; set; }
        public DateTime? TimeDelete { get; set; }
        public long UserFkCreated { get; set; }
        public long UserFkLastModfiead { get; set; }
    }
}
