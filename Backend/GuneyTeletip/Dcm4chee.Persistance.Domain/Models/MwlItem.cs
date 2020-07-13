using System;
using System.Collections.Generic;

namespace Dcm4chee.Persistance.Domain.Models
{
    public partial class MwlItem
    {
        public long Pk { get; set; }
        public string AccessionNo { get; set; }
        public string AdmissionId { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Institution { get; set; }
        public string Department { get; set; }
        public string LocalAet { get; set; }
        public string Modality { get; set; }
        public string ReqProcId { get; set; }
        public string SpsId { get; set; }
        public string SpsStartDate { get; set; }
        public string SpsStartTime { get; set; }
        public int SpsStatus { get; set; }
        public string StudyIuid { get; set; }
        public DateTime UpdatedTime { get; set; }
        public long? Version { get; set; }
        public long DicomattrsFk { get; set; }
        public long? InstCodeFk { get; set; }
        public long? DeptCodeFk { get; set; }
        public long? AccnoIssuerFk { get; set; }
        public long? AdmidIssuerFk { get; set; }
        public long PatientFk { get; set; }
        public long? PerfPhysNameFk { get; set; }

        public virtual Issuer AccnoIssuerFkNavigation { get; set; }
        public virtual Issuer AdmidIssuerFkNavigation { get; set; }
        public virtual Code DeptCodeFkNavigation { get; set; }
        public virtual Dicomattrs DicomattrsFkNavigation { get; set; }
        public virtual Code InstCodeFkNavigation { get; set; }
        public virtual Patient PatientFkNavigation { get; set; }
        public virtual PersonName PerfPhysNameFkNavigation { get; set; }
    }
}
