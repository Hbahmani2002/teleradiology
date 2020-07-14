using System;
using System.Collections.Generic;

namespace Dcm4chee.Persistance.Domain.Models
{
    public partial class StgcmtResult
    {
        public long Pk { get; set; }
        public string BatchId { get; set; }
        public DateTime CreatedTime { get; set; }
        public string DeviceName { get; set; }
        public string ExporterId { get; set; }
        public string MsgId { get; set; }
        public int? NumFailures { get; set; }
        public int? NumInstances { get; set; }
        public string SeriesIuid { get; set; }
        public string SopIuid { get; set; }
        public int StgcmtStatus { get; set; }
        public string StudyIuid { get; set; }
        public string TransactionUid { get; set; }
        public DateTime UpdatedTime { get; set; }
    }
}
