using System;
using System.Collections.Generic;

namespace Dcm4chee.Persistance.Domain.Models
{
    public partial class Patient
    {
        public Patient()
        {
            InverseMergeFkNavigation = new HashSet<Patient>();
            Mpps = new HashSet<Mpps>();
            MwlItem = new HashSet<MwlItem>();
            Study = new HashSet<Study>();
            Ups = new HashSet<Ups>();
        }

        public long Pk { get; set; }
        public DateTime CreatedTime { get; set; }
        public int FailedVerifications { get; set; }
        public int NumStudies { get; set; }
        public string PatBirthdate { get; set; }
        public string PatCustom1 { get; set; }
        public string PatCustom2 { get; set; }
        public string PatCustom3 { get; set; }
        public string PatSex { get; set; }
        public DateTime UpdatedTime { get; set; }
        public int VerificationStatus { get; set; }
        public DateTime? VerificationTime { get; set; }
        public long? Version { get; set; }
        public long DicomattrsFk { get; set; }
        public long? MergeFk { get; set; }
        public long? PatientIdFk { get; set; }
        public long? PatNameFk { get; set; }
        public long? RespPersonFk { get; set; }

        public virtual Dicomattrs DicomattrsFkNavigation { get; set; }
        public virtual Patient MergeFkNavigation { get; set; }
        public virtual PersonName PatNameFkNavigation { get; set; }
        public virtual PatientId PatientIdFkNavigation { get; set; }
        public virtual PersonName RespPersonFkNavigation { get; set; }
        public virtual ICollection<Patient> InverseMergeFkNavigation { get; set; }
        public virtual ICollection<Mpps> Mpps { get; set; }
        public virtual ICollection<MwlItem> MwlItem { get; set; }
        public virtual ICollection<Study> Study { get; set; }
        public virtual ICollection<Ups> Ups { get; set; }
    }
}
