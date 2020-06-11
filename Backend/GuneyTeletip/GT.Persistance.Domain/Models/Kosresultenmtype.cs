using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain.Models
{
    public partial class Kosresultenmtype
    {
        public long EnmId { get; set; }
        public string EnmAd { get; set; }
        public DateTime? TimeCreated { get; set; }
        public DateTime? TimeDelete { get; set; }
        public long UserFkCreated { get; set; }
        public long UserFkLastModfiead { get; set; }
        public long Pk { get; set; }
    }
}
