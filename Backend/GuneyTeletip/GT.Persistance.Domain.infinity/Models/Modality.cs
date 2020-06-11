using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain.infinity.Models
{
    public partial class Modality
    {
        public string ModalityCode { get; set; }
        public string ModalityDesc { get; set; }
        public string ModalityStat { get; set; }
        public DateTime? LastPerformed { get; set; }
        public decimal? PerformedCount { get; set; }
        public decimal? Rvu { get; set; }
    }
}
