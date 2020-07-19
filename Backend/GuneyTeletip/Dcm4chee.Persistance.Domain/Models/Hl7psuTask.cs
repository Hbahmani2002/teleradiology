using System;
using System.Collections.Generic;

namespace Dcm4chee.Persistance.Domain.Models
{
    public partial class Hl7psuTask
    {
        public long Pk { get; set; }
        public string Aet { get; set; }
        public DateTime CreatedTime { get; set; }
        public string DeviceName { get; set; }
        public DateTime? ScheduledTime { get; set; }
        public string SeriesIuid { get; set; }
        public string StudyIuid { get; set; }
        public long? MppsFk { get; set; }

        public virtual Mpps MppsFkNavigation { get; set; }
    }
}
