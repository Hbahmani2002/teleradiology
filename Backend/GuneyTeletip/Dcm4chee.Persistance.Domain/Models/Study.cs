using System;
using System.Collections.Generic;

namespace Dcm4chee.Persistance.Domain.Models
{
    public partial class Study
    {
        public Study()
        {
            Series = new HashSet<Series>();
            StudyQueryAttrs = new HashSet<StudyQueryAttrs>();
        }

        public long Pk { get; set; }
        public string AccessControlId { get; set; }
        public DateTime AccessTime { get; set; }
        public string AccessionNo { get; set; }
        public string AdmissionId { get; set; }
        public int Completeness { get; set; }
        public DateTime CreatedTime { get; set; }
        public string ExpirationDate { get; set; }
        public string ExpirationExporterId { get; set; }
        public int ExpirationState { get; set; }
        public string ExtRetrieveAet { get; set; }
        public int FailedRetrieves { get; set; }
        public DateTime ModifiedTime { get; set; }
        public int RejectionState { get; set; }
        public long StudySize { get; set; }
        public string StorageIds { get; set; }
        public string StudyCustom1 { get; set; }
        public string StudyCustom2 { get; set; }
        public string StudyCustom3 { get; set; }
        public string StudyDate { get; set; }
        public string StudyDesc { get; set; }
        public string StudyId { get; set; }
        public string StudyIuid { get; set; }
        public string StudyTime { get; set; }
        public DateTime UpdatedTime { get; set; }
        public long? Version { get; set; }
        public long DicomattrsFk { get; set; }
        public long? AccnoIssuerFk { get; set; }
        public long? AdmidIssuerFk { get; set; }
        public long PatientFk { get; set; }
        public long? RefPhysNameFk { get; set; }

        public virtual Issuer AccnoIssuerFkNavigation { get; set; }
        public virtual Issuer AdmidIssuerFkNavigation { get; set; }
        public virtual Dicomattrs DicomattrsFkNavigation { get; set; }
        public virtual Patient PatientFkNavigation { get; set; }
        public virtual PersonName RefPhysNameFkNavigation { get; set; }
        public virtual ICollection<Series> Series { get; set; }
        public virtual ICollection<StudyQueryAttrs> StudyQueryAttrs { get; set; }
    }
}
