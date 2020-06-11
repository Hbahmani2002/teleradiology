﻿using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain.Models
{
    public partial class InfStudy
    {
        public long Pk { get; set; }
        public long InfFkStudy { get; set; }
        public long TenantFk { get; set; }
        public long InfFkBatch { get; set; }
        public long UserFk { get; set; }
        public long UserFkLastModfiead { get; set; }
        public string PatientId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string StudyDescription { get; set; }
        public string InstitutionName { get; set; }
        public string Modality { get; set; }
        public string AccessionNo { get; set; }
        public string StudyInstanceuid { get; set; }
        public int? InstanceNumber { get; set; }
        public DateTime? DateBirth { get; set; }
        public DateTime? StudyDate { get; set; }
        public string StoragePath { get; set; }
        public string PatinetNameSurname { get; set; }
        public string CihazDeviceSerialNumber { get; set; }
        public string Desc1 { get; set; }
        public string Desc2 { get; set; }
        public string Desc3 { get; set; }
        public DateTime? TimeCreated { get; set; }
        public DateTime? TimeDelete { get; set; }

        public virtual InfBatch InfFkBatchNavigation { get; set; }
    }
}
