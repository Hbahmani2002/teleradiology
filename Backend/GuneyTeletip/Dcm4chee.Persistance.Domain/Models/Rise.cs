using System;
using System.Collections.Generic;

namespace Dcm4chee.Persistance.Domain.Models
{
    public partial class Rise
    {
        public long Pk { get; set; }
        public string HospitalStudyInstanceuid { get; set; }
        public long? Hospitalid { get; set; }
        public string Modalityid { get; set; }
        public string HospitaldataPatientName { get; set; }
        public string HospitaldataPatientid { get; set; }
        public string HospitaldataPatientBirthdate { get; set; }
        public string HospitaldataPatientSex { get; set; }
        public string HospitaldataReferringPhysicianName { get; set; }
        public DateTime? HospitaldataCreatedtime { get; set; }
        public string HospitaldataAccessionNumber { get; set; }
        public string HospitaldataStudyid { get; set; }
        public string HospitaldataDescription { get; set; }
        public long? InstanceCount { get; set; }
        public DateTime? TimeCreated { get; set; }
        public string AeTitle { get; set; }
    }
}
