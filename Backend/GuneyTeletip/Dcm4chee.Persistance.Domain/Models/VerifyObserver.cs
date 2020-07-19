using System;
using System.Collections.Generic;

namespace Dcm4chee.Persistance.Domain.Models
{
    public partial class VerifyObserver
    {
        public long Pk { get; set; }
        public string VerifyDatetime { get; set; }
        public long? ObserverNameFk { get; set; }
        public long? InstanceFk { get; set; }

        public virtual Instance InstanceFkNavigation { get; set; }
        public virtual PersonName ObserverNameFkNavigation { get; set; }
    }
}
