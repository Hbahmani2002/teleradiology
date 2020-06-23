using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain.Models
{
    public partial class KosStudy
    {
        public long Pk { get; set; }
        public long FkTenant { get; set; }
        public long FkInfBatch { get; set; }
        public long? FkUserCreated { get; set; }
        public long? FkUserModfiead { get; set; }
        public long? InfMergeKey { get; set; }
        public string PatientId { get; set; }
        public string Gender { get; set; }
        public string StudyDescription { get; set; }
        public string InstitutionName { get; set; }
        public string Modality { get; set; }
        public string AccessionNo { get; set; }
        public string StudyInstanceuid { get; set; }
        public string SeriesInfo { get; set; }
        public int? ZeroImg { get; set; }
        public int? InstanceCount { get; set; }
        public DateTime? DateBirth { get; set; }
        public DateTime? StudyDate { get; set; }
        public string StoragePath { get; set; }
        public string PatinetNameSurname { get; set; }
        public string CihazDeviceSerialNumber { get; set; }
        public string Desc1 { get; set; }
        public string Desc2 { get; set; }
        public string Desc3 { get; set; }
        public DateTime? TimeCreated { get; set; }
        public DateTime? TimeModified { get; set; }
        public string Institution { get; set; }
        public int? SeriesCount { get; set; }
        public long? SeriesKey { get; set; }
        public long? InstanceKey { get; set; }
        public string FileName { get; set; }
        public string ValumeCode { get; set; }
        public string ValumeType { get; set; }
        public string ValumeStat { get; set; }
        public string ValumePathname { get; set; }
        public DateTime? CreationDttm { get; set; }
        public long? OracleStudyKey { get; set; }
        public long? FkKosEnumType { get; set; }
    }
}
