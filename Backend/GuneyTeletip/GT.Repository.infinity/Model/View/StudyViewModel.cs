using GT.UTILS.GRID;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT.Repository.infinity.Model.View
{
    public class StudyViewModel
    {
        [DataEntityID]
        public string PatientID { get; set; }
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }
        public string PatientSex { get; set; }
        public string AccessNo { get; set; }
        public string Modalities { get; set; }
        public string StudyInstanceUID { get; set; }
        public decimal? InstanceCount { get; set; }
    }
}
