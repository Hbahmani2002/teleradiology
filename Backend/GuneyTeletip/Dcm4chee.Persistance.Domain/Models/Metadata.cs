using System;
using System.Collections.Generic;

namespace Dcm4chee.Persistance.Domain.Models
{
    public partial class Metadata
    {
        public Metadata()
        {
            Series = new HashSet<Series>();
        }

        public long Pk { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Digest { get; set; }
        public long ObjectSize { get; set; }
        public int Status { get; set; }
        public string StorageId { get; set; }
        public string StoragePath { get; set; }

        public virtual ICollection<Series> Series { get; set; }
    }
}
