using System;
using System.Collections.Generic;

namespace Dcm4chee.Persistance.Domain.Models
{
    public partial class Location
    {
        public long Pk { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Digest { get; set; }
        public int? MultiRef { get; set; }
        public int ObjectType { get; set; }
        public long ObjectSize { get; set; }
        public int Status { get; set; }
        public string StorageId { get; set; }
        public string StoragePath { get; set; }
        public string Tsuid { get; set; }
        public long? InstanceFk { get; set; }
        public long? UidmapFk { get; set; }

        public virtual Instance InstanceFkNavigation { get; set; }
        public virtual Uidmap UidmapFkNavigation { get; set; }
    }
}
