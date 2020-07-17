using System;
using System.Collections.Generic;

namespace Dcm4chee.Persistance.Domain.Models
{
    public partial class StgverTask
    {
        public long Pk { get; set; }
        public int Completed { get; set; }
        public DateTime CreatedTime { get; set; }
        public int Failed { get; set; }
        public string LocalAet { get; set; }
        public string SeriesIuid { get; set; }
        public string SopIuid { get; set; }
        public string StorageIds { get; set; }
        public int? StgcmtPolicy { get; set; }
        public string StudyIuid { get; set; }
        public bool? UpdateLocationStatus { get; set; }
        public DateTime UpdatedTime { get; set; }
        public long QueueMsgFk { get; set; }

        public virtual QueueMsg QueueMsgFkNavigation { get; set; }
    }
}
