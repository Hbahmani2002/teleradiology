using System;
using System.Collections.Generic;

namespace Dcm4chee.Persistance.Domain.Models
{
    public partial class GlobalSubscription
    {
        public long Pk { get; set; }
        public bool DeletionLock { get; set; }
        public string SubscriberAet { get; set; }
        public long? MatchkeysFk { get; set; }

        public virtual Dicomattrs MatchkeysFkNavigation { get; set; }
    }
}
