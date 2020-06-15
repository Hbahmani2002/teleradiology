using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain.Models
{
    public partial class XxxDicomData
    {
        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public bool IsDeleted { get; set; }
        public long? DeleterUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public int TenantId { get; set; }
        public int? RandevuId { get; set; }
        public string PatientId { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Gender { get; set; }
        public string StudyId { get; set; }
        public string StudyDescription { get; set; }
        public string InstanceAvailability { get; set; }
        public string InstitutionName { get; set; }
        public string Modality { get; set; }
        public string AccessionNo { get; set; }
        public string StudyInstanceUid { get; set; }
        public int InstanceNumber { get; set; }
        public int NumberOfStudyRelatedInstances { get; set; }
        public int NumberOfStudyRelatedSeries { get; set; }
        public DateTime? PatientBirthDate { get; set; }
        public DateTime StudyDate { get; set; }
        public int? TetkikIstekId { get; set; }
        public string StoragePath { get; set; }
        public string PatientName { get; set; }
        public int AccNoDegisimSayi { get; set; }
        public int KosState { get; set; }
        public DateTime? TarihtenSonraSil { get; set; }
        public string SendHl7ForAccession { get; set; }
        public string DeviceSerialNumber { get; set; }
    }
}
