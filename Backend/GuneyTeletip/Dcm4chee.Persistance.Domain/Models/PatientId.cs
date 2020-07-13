using System;
using System.Collections.Generic;

namespace Dcm4chee.Persistance.Domain.Models
{
    public partial class PatientId
    {
        public PatientId()
        {
            Patient = new HashSet<Patient>();
        }

        public long Pk { get; set; }
        public string PatId { get; set; }
        public string PatIdTypeCode { get; set; }
        public long? Version { get; set; }
        public long? IssuerFk { get; set; }

        public virtual Issuer IssuerFkNavigation { get; set; }
        public virtual ICollection<Patient> Patient { get; set; }
    }
}
