using System;
using System.Collections.Generic;

namespace Dcm4chee.Persistance.Domain.Models
{
    public partial class RetrieveTask
    {
        public long Pk { get; set; }
        public string BatchId { get; set; }
        public int Completed { get; set; }
        public DateTime CreatedTime { get; set; }
        public string DestinationAet { get; set; }
        public string DeviceName { get; set; }
        public string ErrorComment { get; set; }
        public int Failed { get; set; }
        public string LocalAet { get; set; }
        public string QueueName { get; set; }
        public int Remaining { get; set; }
        public string RemoteAet { get; set; }
        public DateTime? ScheduledTime { get; set; }
        public string SeriesIuid { get; set; }
        public string SopIuid { get; set; }
        public int StatusCode { get; set; }
        public string StudyIuid { get; set; }
        public DateTime UpdatedTime { get; set; }
        public int Warning { get; set; }
        public long? QueueMsgFk { get; set; }

        public virtual QueueMsg QueueMsgFkNavigation { get; set; }
    }
}
