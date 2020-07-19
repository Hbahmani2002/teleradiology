using System;
using System.Collections.Generic;

namespace Dcm4chee.Persistance.Domain.Models
{
    public partial class ContentItem
    {
        public long Pk { get; set; }
        public string RelType { get; set; }
        public string TextValue { get; set; }
        public long? CodeFk { get; set; }
        public long NameFk { get; set; }
        public long? InstanceFk { get; set; }

        public virtual Code CodeFkNavigation { get; set; }
        public virtual Instance InstanceFkNavigation { get; set; }
        public virtual Code NameFkNavigation { get; set; }
    }
}
