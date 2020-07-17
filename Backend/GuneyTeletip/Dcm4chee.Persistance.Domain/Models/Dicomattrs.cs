using System;
using System.Collections.Generic;

namespace Dcm4chee.Persistance.Domain.Models
{
    public partial class Dicomattrs
    {
        public Dicomattrs()
        {
            GlobalSubscription = new HashSet<GlobalSubscription>();
        }

        public long Pk { get; set; }
        public byte[] Attrs { get; set; }

        public virtual Instance Instance { get; set; }
        public virtual Mpps Mpps { get; set; }
        public virtual MwlItem MwlItem { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Series Series { get; set; }
        public virtual Study Study { get; set; }
        public virtual Ups Ups { get; set; }
        public virtual ICollection<GlobalSubscription> GlobalSubscription { get; set; }
    }
}
