using System;
using System.Collections.Generic;
using System.Text;

namespace GT.Repository.Models.View
{
    public class OrderStatusForAccessionNumberViewModel
    {
        public long? ID { get; set; }
        public long? FkTenant { get; set; }
        public long? FkInfBatch { get; set; }
        public long? FkKosStudy { get; set; }
        public string Accessionnumber { get; set; }
        public string Citizenid { get; set; }
        public string Teletipstatus { get; set; }
        public int? Teletipstatusid { get; set; }
        public string Medulastatus { get; set; }
        public int? Medulastatusid { get; set; }
        public string Wadostatus { get; set; }
        public int? Wadostatusid { get; set; }
        public string Reportstatus { get; set; }
        public int? Reportstatusid { get; set; }
        public string Dosestatus { get; set; }
        public int? Dosestatusid { get; set; }
        public string Medulainstitutionid { get; set; }
        public string Sutcode { get; set; }
        public DateTime? Lastmedulasenddate { get; set; }
        public string Medularesponsecode { get; set; }
        public string Medularesponsemessage { get; set; }
        public DateTime? Scheduledate { get; set; }
        public DateTime? Performeddate { get; set; }
        public string Error { get; set; }
        public string Patienthistorysearchstatus { get; set; }
        public int? Patienthistorysearchstatusid { get; set; }
        public string SkrsKod { get; set; }
        public DateTime? TimeCreated { get; set; }
        public DateTime? TimeModified { get; set; }
        public int? FkUserCreated { get; set; }
        public int? FkUserModified { get; set; }
   
    }
}
