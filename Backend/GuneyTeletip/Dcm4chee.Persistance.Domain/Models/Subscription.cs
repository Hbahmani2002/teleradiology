using System;
using System.Collections.Generic;

namespace Dcm4chee.Persistance.Domain.Models
{
    public partial class Subscription
    {
        public long Pk { get; set; }
        public bool DeletionLock { get; set; }
        public string SubscriberAet { get; set; }
        public long UpsFk { get; set; }

        public virtual Ups UpsFkNavigation { get; set; }
    }
}
