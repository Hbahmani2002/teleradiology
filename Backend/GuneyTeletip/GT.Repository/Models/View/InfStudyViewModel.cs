
using GT.UTILS.GRID;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT.Repository.Models.View
{
    public class InfStudyViewModel
    {
        [DataEntityID]
        public long ID { get; set; }
        public string AccessionNumber { get; set; }
        public string HastaNo { get; set; }
        public string PatientName { get; set; }
        public string IstemAdi { get; set; }
        public DateTime IstemTarihi { get; set; }
        public string Modality { get; set; }
        public string KosStateTag { get; set; }
        public int KosState { get; set; }
        public long? TenantID { get; set; }
        public long? InfBatchID { get; set; }
        public long? UserIDCreated { get; set; }
        public long? UserIDModfiead { get; set; }
        public string PatientID { get; set; }
        public string Gender { get; set; }
        public string StudyDescription { get; set; }
        public string InstitutionName { get; set; }
        public string StudyInstanceuid { get; set; }
        public int? InstanceCount { get; set; }
        public DateTime? DateBirth { get; set; }
        public DateTime? StudyDate { get; set; }
        public string StoragePath { get; set; }
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
        public decimal? OracleStudyKey { get; set; }
        public string DicomDirPath { get; set; }
    }

        public class InfStudyViewModel1
        {
         public string AccessionNumber { get; set; }
        }
    }
