using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain.infinity.Models
{
    public partial class Series
    {
        public Series()
        {
            Instance = new HashSet<Instance>();
        }

        public decimal SeriesKey { get; set; }
        public decimal StudyKey { get; set; }
        public string SeriesInstanceUid { get; set; }
        public string SeriesStat { get; set; }
        public string Modality { get; set; }
        public decimal? SeriesNo { get; set; }
        public DateTime? SeriesDttm { get; set; }
        public string SeriesInfo { get; set; }
        public string SeriesDesc { get; set; }
        public string Bodypart { get; set; }
        public string Operator { get; set; }
        public string PerformDoctor { get; set; }
        public string PpsId { get; set; }
        public DateTime? PpsStartDttm { get; set; }
        public string PpsDesc { get; set; }
        public decimal? SeriesSize { get; set; }
        public decimal? InstanceCount { get; set; }
        public decimal? Ordinal { get; set; }
        public DateTime? PerformedProcStartDttm { get; set; }
        public string RequestAttrs { get; set; }
        public string Temporary { get; set; }
        public string FilterInfo { get; set; }

        public virtual Study StudyKeyNavigation { get; set; }
        public virtual ICollection<Instance> Instance { get; set; }
    }
}
