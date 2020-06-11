using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain.infinity.Models
{
    public partial class Instance
    {
        public decimal InstanceKey { get; set; }
        public string InstanceStat { get; set; }
        public string SopInstanceUid { get; set; }
        public decimal SopClassKey { get; set; }
        public decimal SeriesKey { get; set; }
        public decimal StudyKey { get; set; }
        public decimal? InstanceNo { get; set; }
        public DateTime? ContentDttm { get; set; }
        public decimal? Ordinal { get; set; }
        public decimal? ConcateKey { get; set; }
        public decimal? InstanceframeCount { get; set; }
        public decimal? TransferSyntaxKey { get; set; }
        public decimal? TransferSyntaxKeyB0 { get; set; }
        public decimal? TransferSyntaxKeyB1 { get; set; }
        public decimal? TransferSyntaxKeyB2 { get; set; }
        public decimal? TransferSyntaxKeyB3 { get; set; }

        public virtual Series SeriesKeyNavigation { get; set; }
        public virtual Study StudyKeyNavigation { get; set; }
    }
}
