using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain
{
    public partial class KosInstance
    {
        public long Pk { get; set; }
        public string PatientId { get; set; }
        public string PatinetName { get; set; }
        public long? OracleStudyKey { get; set; }
        public string StudyInstanceuid { get; set; }
        public string SeriInstanceuid { get; set; }
        public string SopInstanceuid { get; set; }
        public string Modality { get; set; }
        public string AccessionNo { get; set; }
        public string SeriInfo { get; set; }
        public string InstitutionFilename { get; set; }
        public string InstitutionPathname { get; set; }
        public string VolumePath { get; set; }
        public DateTime? TimeCreated { get; set; }
        public DateTime? TimeDelete { get; set; }
        public long UserFk { get; set; }
        public long UserFkLastModfiead { get; set; }
        public long InstanceLocKey { get; set; }
        public string InstanceDcmdirPath { get; set; }
    }
}
