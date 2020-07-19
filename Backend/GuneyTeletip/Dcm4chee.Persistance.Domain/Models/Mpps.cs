using System;
using System.Collections.Generic;

namespace Dcm4chee.Persistance.Domain.Models
{
    public partial class Mpps
    {
        public Mpps()
        {
            Hl7psuTask = new HashSet<Hl7psuTask>();
            IanTask = new HashSet<IanTask>();
        }

        public long Pk { get; set; }
        public string AccessionNo { get; set; }
        public DateTime CreatedTime { get; set; }
        public string PpsStartDate { get; set; }
        public string PpsStartTime { get; set; }
        public string SopIuid { get; set; }
        public int PpsStatus { get; set; }
        public string StudyIuid { get; set; }
        public DateTime UpdatedTime { get; set; }
        public long? Version { get; set; }
        public long DicomattrsFk { get; set; }
        public long? DiscreasonCodeFk { get; set; }
        public long? AccnoIssuerFk { get; set; }
        public long PatientFk { get; set; }

        public virtual Issuer AccnoIssuerFkNavigation { get; set; }
        public virtual Dicomattrs DicomattrsFkNavigation { get; set; }
        public virtual Code DiscreasonCodeFkNavigation { get; set; }
        public virtual Patient PatientFkNavigation { get; set; }
        public virtual ICollection<Hl7psuTask> Hl7psuTask { get; set; }
        public virtual ICollection<IanTask> IanTask { get; set; }
    }
}
