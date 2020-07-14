using System;
using System.Collections.Generic;

namespace Dcm4chee.Persistance.Domain.Models
{
    public partial class ExportTask
    {
        public long Pk { get; set; }
        public string BatchId { get; set; }
        public DateTime CreatedTime { get; set; }
        public string DeviceName { get; set; }
        public string ExporterId { get; set; }
        public string Modalities { get; set; }
        public int? NumInstances { get; set; }
        public DateTime? ScheduledTime { get; set; }
        public string SeriesIuid { get; set; }
        public string SopIuid { get; set; }
        public string StudyIuid { get; set; }
        public DateTime UpdatedTime { get; set; }
        public long? Version { get; set; }
        public long? QueueMsgFk { get; set; }

        public virtual QueueMsg QueueMsgFkNavigation { get; set; }
    }
}
