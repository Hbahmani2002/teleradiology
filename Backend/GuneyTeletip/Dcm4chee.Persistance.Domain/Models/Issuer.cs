using System;
using System.Collections.Generic;

namespace Dcm4chee.Persistance.Domain.Models
{
    public partial class Issuer
    {
        public Issuer()
        {
            Mpps = new HashSet<Mpps>();
            MwlItemAccnoIssuerFkNavigation = new HashSet<MwlItem>();
            MwlItemAdmidIssuerFkNavigation = new HashSet<MwlItem>();
            PatientId = new HashSet<PatientId>();
            SeriesReq = new HashSet<SeriesReq>();
            StudyAccnoIssuerFkNavigation = new HashSet<Study>();
            StudyAdmidIssuerFkNavigation = new HashSet<Study>();
            Ups = new HashSet<Ups>();
            UpsReq = new HashSet<UpsReq>();
        }

        public long Pk { get; set; }
        public string EntityId { get; set; }
        public string EntityUid { get; set; }
        public string EntityUidType { get; set; }

        public virtual ICollection<Mpps> Mpps { get; set; }
        public virtual ICollection<MwlItem> MwlItemAccnoIssuerFkNavigation { get; set; }
        public virtual ICollection<MwlItem> MwlItemAdmidIssuerFkNavigation { get; set; }
        public virtual ICollection<PatientId> PatientId { get; set; }
        public virtual ICollection<SeriesReq> SeriesReq { get; set; }
        public virtual ICollection<Study> StudyAccnoIssuerFkNavigation { get; set; }
        public virtual ICollection<Study> StudyAdmidIssuerFkNavigation { get; set; }
        public virtual ICollection<Ups> Ups { get; set; }
        public virtual ICollection<UpsReq> UpsReq { get; set; }
    }
}
