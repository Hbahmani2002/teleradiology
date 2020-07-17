using System;
using System.Collections.Generic;

namespace Dcm4chee.Persistance.Domain.Models
{
    public partial class IanTask
    {
        public long Pk { get; set; }
        public string CallingAet { get; set; }
        public string DeviceName { get; set; }
        public string IanDests { get; set; }
        public DateTime? ScheduledTime { get; set; }
        public string StudyIuid { get; set; }
        public long? MppsFk { get; set; }

        public virtual Mpps MppsFkNavigation { get; set; }
    }
}
