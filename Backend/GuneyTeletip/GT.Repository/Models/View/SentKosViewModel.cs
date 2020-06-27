using System;
using System.Collections.Generic;
using System.Text;

namespace GT.Repository.Models.View
{
    public class SentKosViewModel
    {
        public string PatientId { get; set; }
        public string DicomPath { get; set; }
        public long StudyID { get; set; }
    }
}
