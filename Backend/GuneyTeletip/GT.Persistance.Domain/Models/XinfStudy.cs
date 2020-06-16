using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain.Models
{
    public partial class XinfStudy
    {
        public double StudyKey { get; set; }
        public double? OrderKey { get; set; }
        public double? MergeKey { get; set; }
        public string PatientId { get; set; }
        public string PatientIdIssuer { get; set; }
        public string PatientName { get; set; }
        public string OtherPatientId { get; set; }
        public string OtherPatientIdIssuer { get; set; }
        public string OtherPatientName { get; set; }
        public char? PatientSex { get; set; }
        public DateTime? PatientBirthDttm { get; set; }
        public string PatientAge { get; set; }
        public double? PatientAgeInDays { get; set; }
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
        public char? StsStat { get; set; }
        public double? LtaCount { get; set; }
        public double? StudySize { get; set; }
        public double? MspsCount { get; set; }
        public double? SeriesCount { get; set; }
        public double? InstanceCount { get; set; }
        public DateTime CreationDttm { get; set; }
        public DateTime? AccessDttm { get; set; }
        public double StudyStat { get; set; }
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
        public double? ProcplanKey { get; set; }
        public string RequestDoctor { get; set; }
        public string RequestCode { get; set; }
        public string RequestName { get; set; }
        public DateTime? RequestDttm { get; set; }
        public string RequestDepartment { get; set; }
        public string SpecialNeeds { get; set; }
        public double? VerifierKey { get; set; }
        public DateTime? VerifyDttm { get; set; }
        public string Specialty { get; set; }
        public string Passcode { get; set; }
        public string Diagnosis { get; set; }
        public double? DreaderKey { get; set; }
        public DateTime? DreadDttm { get; set; }
        public double? TreaderKey { get; set; }
        public DateTime? TreadDttm { get; set; }
        public DateTime? ValidateDttm { get; set; }
        public DateTime? ModifyDttm { get; set; }
        public DateTime? AdmitDttm { get; set; }
        public DateTime? ScheduledDttm { get; set; }
        public DateTime? RegisterDttm { get; set; }
        public double? EdStat { get; set; }
        public double? RequestStat { get; set; }
        public char? ConfirmStat { get; set; }
        public char? BillingStat { get; set; }
        public double? AddendumStat { get; set; }
        public DateTime? LastPrintDttm { get; set; }
        public double? LastPrintUserKey { get; set; }
        public char? PrintStat { get; set; }
        public string EnglishPatientName { get; set; }
        public string HideCode { get; set; }
        public char? StayinStat { get; set; }
        public string StudySsn { get; set; }
        public DateTime? OrderDttm { get; set; }
        public string JobUid { get; set; }
        public DateTime? CompletedDttm { get; set; }
        public char? Requestexam { get; set; }
        public char? Protected { get; set; }
        public char? WetReading { get; set; }
        public DateTime? AssignedDttm { get; set; }
    }
}
