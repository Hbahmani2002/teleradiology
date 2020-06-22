using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain.Models
{
    public partial class KosBatch
    {
        public KosBatch()
        {
            KosStudy = new HashSet<KosStudy>();
        }

        public long Pk { get; set; }
        public DateTime? TimeCreated { get; set; }
        public long? FkUserCreated { get; set; }
        public long? FkUserModified { get; set; }
        public DateTime? TimeModified { get; set; }

        public virtual ICollection<KosStudy> KosStudy { get; set; }
    }
}
