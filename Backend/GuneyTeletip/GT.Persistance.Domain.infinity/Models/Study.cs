using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain.infinity.Models
{
    public partial class Study
    {
        public Study()
        {
            Instance = new HashSet<Instance>();
            Series = new HashSet<Series>();
        }

        public decimal StudyKey { get; set; }
        public decimal? OrderKey { get; set; }
        public decimal? MergeKey { get; set; }
        public string PatientId { get; set; }
        public string PatientIdIssuer { get; set; }
        public string PatientName { get; set; }
        public string OtherPatientId { get; set; }
        public string OtherPatientIdIssuer { get; set; }
        public string OtherPatientName { get; set; }
        public string PatientSex { get; set; }
        public DateTime? PatientBirthDttm { get; set; }
        public string PatientAge { get; set; }
        public decimal? PatientAgeInDays { get; set; }
        public string PatientWeight { get; set; }
        public string PatientSize { get; set; }
        public string PatientLocation { get; set; }
        public string PatientResidency { get; set; }
        public string PatientArrange { get; set; }
        public string PatientAccountNo { get; set; }
        public string StudyInstanceUid { get; set; }
        public string StudyId { get; set; }
        public DateTime? StudyDttm { get; set; }
        public string AccessNo { get; set; }
        public string StudyDesc { get; set; }
        public string ReferDoctor { get; set; }
        public string ReadDoctor { get; set; }
        public string Department { get; set; }
        public string Institution { get; set; }
        public string StsStat { get; set; }
        public decimal? LtaCount { get; set; }
        public decimal? StudySize { get; set; }
        public decimal? MspsCount { get; set; }
        public decimal? SeriesCount { get; set; }
        public decimal? InstanceCount { get; set; }
        public DateTime CreationDttm { get; set; }
        public DateTime? AccessDttm { get; set; }
        public decimal StudyStat { get; set; }
        public string Modalities { get; set; }
        public string Bodyparts { get; set; }
        public string Operators { get; set; }
        public string SourceAetitle { get; set; }
        public string StudyPriority { get; set; }
        public string StudyReason { get; set; }
        public string StudyComments { get; set; }
        public string AttendDoctor { get; set; }
        public string PerformDoctor { get; set; }
        public string ConsultDoctor { get; set; }
        public decimal? ProcplanKey { get; set; }
        public string RequestDoctor { get; set; }
        public string RequestCode { get; set; }
        public string RequestName { get; set; }
        public DateTime? RequestDttm { get; set; }
        public string RequestDepartment { get; set; }
        public string SpecialNeeds { get; set; }
        public decimal? VerifierKey { get; set; }
        public DateTime? VerifyDttm { get; set; }
        public string Specialty { get; set; }
        public string Passcode { get; set; }
        public string Diagnosis { get; set; }
        public decimal? DreaderKey { get; set; }
        public DateTime? DreadDttm { get; set; }
        public decimal? TreaderKey { get; set; }
        public DateTime? TreadDttm { get; set; }
        public DateTime? ValidateDttm { get; set; }
        public DateTime? ModifyDttm { get; set; }
        public DateTime? AdmitDttm { get; set; }
        public DateTime? ScheduledDttm { get; set; }
        public DateTime? RegisterDttm { get; set; }
        public decimal? EdStat { get; set; }
        public decimal? RequestStat { get; set; }
        public string ConfirmStat { get; set; }
        public string BillingStat { get; set; }
        public decimal? AddendumStat { get; set; }
        public DateTime? LastPrintDttm { get; set; }
        public decimal? LastPrintUserKey { get; set; }
        public string PrintStat { get; set; }
        public string EnglishPatientName { get; set; }
        public string HideCode { get; set; }
        public string StayinStat { get; set; }
        public string StudySsn { get; set; }
        public DateTime? OrderDttm { get; set; }
        public string JobUid { get; set; }
        public DateTime? CompletedDttm { get; set; }
        public string Requestexam { get; set; }
        public string Protected { get; set; }
        public string WetReading { get; set; }
        public DateTime? AssignedDttm { get; set; }

        public virtual ICollection<Instance> Instance { get; set; }
        public virtual ICollection<Series> Series { get; set; }
    }
}
