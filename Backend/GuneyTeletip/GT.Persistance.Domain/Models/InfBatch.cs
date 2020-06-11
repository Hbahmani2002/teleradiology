using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain.Models
{
    public partial class InfBatch
    {
        public InfBatch()
        {
            InfStudy = new HashSet<InfStudy>();
        }

        public long Pk { get; set; }
        public DateTime? Tarih { get; set; }
        public DateTime? TimeCreated { get; set; }
        public DateTime? TimeDelete { get; set; }
        public long UserFkCreated { get; set; }
        public long UserFkLastModfiead { get; set; }

        public virtual ICollection<InfStudy> InfStudy { get; set; }
    }
}
