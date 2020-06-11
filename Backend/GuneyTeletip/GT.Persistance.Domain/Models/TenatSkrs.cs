using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain.Models
{
    public partial class TenatSkrs
    {
        public long Pk { get; set; }
        public long TenatFk { get; set; }
        public long SkrsFk { get; set; }
        public DateTime? TimeCreated { get; set; }
        public DateTime? TimeDelete { get; set; }
        public long UserFk { get; set; }
        public long UserFkLastModfiead { get; set; }

        public virtual Skrs SkrsFkNavigation { get; set; }
        public virtual Tenat TenatFkNavigation { get; set; }
    }
}
