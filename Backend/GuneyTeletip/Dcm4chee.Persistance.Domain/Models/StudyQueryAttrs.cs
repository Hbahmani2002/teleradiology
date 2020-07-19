using System;
using System.Collections.Generic;

namespace Dcm4chee.Persistance.Domain.Models
{
    public partial class StudyQueryAttrs
    {
        public long Pk { get; set; }
        public int? Availability { get; set; }
        public string ModsInStudy { get; set; }
        public int? NumInstances { get; set; }
        public int? NumSeries { get; set; }
        public string RetrieveAets { get; set; }
        public string CuidsInStudy { get; set; }
        public string ViewId { get; set; }
        public long StudyFk { get; set; }

        public virtual Study StudyFkNavigation { get; set; }
    }
}
