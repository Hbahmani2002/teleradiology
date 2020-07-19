using GT.UTILS.GRID;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dcm4chee.Repository.Models
{
    public class DcmViewModel
    {
        [DataEntityID]
        public long LocationID { get; set; }
        public long InstanseID { get; set; }
        public string SopCuid { get; set; }
        public long SeriesID { get; set; }
        public string SeriesCuid { get; set; }
        public long StudyID { get; set; }
        public string StudyCuid { get; set; }
        public long? InstanceID { get; set; }
        public long PatientID { get; set; }
        public long StudyPatientID { get; set; }
        public long PersonNameID { get; set; }
        public long Accessionno { get; set; }
        public string FamilyName { get; set; }
        public string StoragePath { get; set; }
        public long? PatID { get; set; }
        public string Modality { get; set; }
    }
}
