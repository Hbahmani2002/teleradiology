using System;
using System.Collections.Generic;

namespace Dcm4chee.Persistance.Domain.Models
{
    public partial class PersonName
    {
        public PersonName()
        {
            MwlItem = new HashSet<MwlItem>();
            PatientPatNameFkNavigation = new HashSet<Patient>();
            PatientRespPersonFkNavigation = new HashSet<Patient>();
            Series = new HashSet<Series>();
            SeriesReq = new HashSet<SeriesReq>();
            SoundexCode = new HashSet<SoundexCode>();
            Study = new HashSet<Study>();
            UpsReq = new HashSet<UpsReq>();
            VerifyObserver = new HashSet<VerifyObserver>();
        }

        public long Pk { get; set; }
        public string FamilyName { get; set; }
        public string GivenName { get; set; }
        public string IFamilyName { get; set; }
        public string IGivenName { get; set; }
        public string IMiddleName { get; set; }
        public string INamePrefix { get; set; }
        public string INameSuffix { get; set; }
        public string MiddleName { get; set; }
        public string NamePrefix { get; set; }
        public string NameSuffix { get; set; }
        public string PFamilyName { get; set; }
        public string PGivenName { get; set; }
        public string PMiddleName { get; set; }
        public string PNamePrefix { get; set; }
        public string PNameSuffix { get; set; }

        public virtual ICollection<MwlItem> MwlItem { get; set; }
        public virtual ICollection<Patient> PatientPatNameFkNavigation { get; set; }
        public virtual ICollection<Patient> PatientRespPersonFkNavigation { get; set; }
        public virtual ICollection<Series> Series { get; set; }
        public virtual ICollection<SeriesReq> SeriesReq { get; set; }
        public virtual ICollection<SoundexCode> SoundexCode { get; set; }
        public virtual ICollection<Study> Study { get; set; }
        public virtual ICollection<UpsReq> UpsReq { get; set; }
        public virtual ICollection<VerifyObserver> VerifyObserver { get; set; }
    }
}
