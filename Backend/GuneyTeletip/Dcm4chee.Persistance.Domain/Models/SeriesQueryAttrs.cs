using System;
using System.Collections.Generic;

namespace Dcm4chee.Persistance.Domain.Models
{
    public partial class SeriesQueryAttrs
    {
        public long Pk { get; set; }
        public int? Availability { get; set; }
        public int? NumInstances { get; set; }
        public string RetrieveAets { get; set; }
        public string CuidsInSeries { get; set; }
        public string ViewId { get; set; }
        public long SeriesFk { get; set; }

        public virtual Series SeriesFkNavigation { get; set; }
    }
}
