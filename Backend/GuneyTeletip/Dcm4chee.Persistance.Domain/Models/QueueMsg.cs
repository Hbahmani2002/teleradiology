using System;
using System.Collections.Generic;

namespace Dcm4chee.Persistance.Domain.Models
{
    public partial class QueueMsg
    {
        public QueueMsg()
        {
            DiffTask = new HashSet<DiffTask>();
            ExportTask = new HashSet<ExportTask>();
            RetrieveTask = new HashSet<RetrieveTask>();
            StgverTask = new HashSet<StgverTask>();
        }

        public long Pk { get; set; }
        public string BatchId { get; set; }
        public DateTime CreatedTime { get; set; }
        public string DeviceName { get; set; }
        public string ErrorMsg { get; set; }
        public byte[] MsgBody { get; set; }
        public string MsgId { get; set; }
        public string MsgProps { get; set; }
        public int NumFailures { get; set; }
        public string OutcomeMsg { get; set; }
        public int Priority { get; set; }
        public DateTime? ProcEndTime { get; set; }
        public DateTime? ProcStartTime { get; set; }
        public string QueueName { get; set; }
        public DateTime ScheduledTime { get; set; }
        public int MsgStatus { get; set; }
        public DateTime UpdatedTime { get; set; }
        public long? Version { get; set; }

        public virtual ICollection<DiffTask> DiffTask { get; set; }
        public virtual ICollection<ExportTask> ExportTask { get; set; }
        public virtual ICollection<RetrieveTask> RetrieveTask { get; set; }
        public virtual ICollection<StgverTask> StgverTask { get; set; }
    }
}
