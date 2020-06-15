using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain.Models
{
    public partial class XinfSeries
    {
        public double SeriesKey { get; set; }
        public double StudyKey { get; set; }
        public string SeriesInstanceUid { get; set; }
        public char SeriesStat { get; set; }
        public string Modality { get; set; }
        public double? SeriesNo { get; set; }
        public DateTime? SeriesDttm { get; set; }
        public string SeriesInfo { get; set; }
        public string SeriesDesc { get; set; }
        public string Bodypart { get; set; }
        public string Operator { get; set; }
        public string PerformDoctor { get; set; }
        public string PpsId { get; set; }
        public DateTime? PpsStartDttm { get; set; }
        public string PpsDesc { get; set; }
        public double? SeriesSize { get; set; }
        public double? InstanceCount { get; set; }
        public double? Ordinal { get; set; }
        public DateTime? PerformedProcStartDttm { get; set; }
        public string RequestAttrs { get; set; }
        public char? Temporary { get; set; }
        public string FilterInfo { get; set; }
    }
}
