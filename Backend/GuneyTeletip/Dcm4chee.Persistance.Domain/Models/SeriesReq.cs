using System;
using System.Collections.Generic;

namespace Dcm4chee.Persistance.Domain.Models
{
    public partial class SeriesReq
    {
        public long Pk { get; set; }
        public string AccessionNo { get; set; }
        public string ReqProcId { get; set; }
        public string ReqService { get; set; }
        public string SpsId { get; set; }
        public string StudyIuid { get; set; }
        public long? AccnoIssuerFk { get; set; }
        public long? ReqPhysNameFk { get; set; }
        public long? SeriesFk { get; set; }

        public virtual Issuer AccnoIssuerFkNavigation { get; set; }
        public virtual PersonName ReqPhysNameFkNavigation { get; set; }
        public virtual Series SeriesFkNavigation { get; set; }
    }
}
