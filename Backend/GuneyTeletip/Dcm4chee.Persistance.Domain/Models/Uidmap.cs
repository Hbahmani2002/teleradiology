using System;
using System.Collections.Generic;

namespace Dcm4chee.Persistance.Domain.Models
{
    public partial class Uidmap
    {
        public Uidmap()
        {
            Location = new HashSet<Location>();
        }

        public long Pk { get; set; }
        public byte[] Uidmap1 { get; set; }

        public virtual ICollection<Location> Location { get; set; }
    }
}
