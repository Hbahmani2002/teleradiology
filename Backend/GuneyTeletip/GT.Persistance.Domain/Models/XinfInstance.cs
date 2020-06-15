using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain.Models
{
    public partial class XinfInstance
    {
        public double InstanceKey { get; set; }
        public char InstanceStat { get; set; }
        public string SopInstanceUid { get; set; }
        public double SopClassKey { get; set; }
        public double SeriesKey { get; set; }
        public double StudyKey { get; set; }
        public double? InstanceNo { get; set; }
        public DateTime? ContentDttm { get; set; }
        public double? Ordinal { get; set; }
        public double? ConcateKey { get; set; }
        public double? InstanceframeCount { get; set; }
        public double? TransferSyntaxKey { get; set; }
        public double? TransferSyntaxKeyB0 { get; set; }
        public double? TransferSyntaxKeyB1 { get; set; }
        public double? TransferSyntaxKeyB2 { get; set; }
        public double? TransferSyntaxKeyB3 { get; set; }
    }
}
