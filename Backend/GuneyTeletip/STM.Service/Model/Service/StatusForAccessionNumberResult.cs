using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teletip.SorgulamaServis
{
    public class StatusForAccessionNumberResult
    {
        public string AccessionNumber { get; set; }
        public string CitizenId { get; set; }
        /// <summary>
        /// TeletipStatus, //Dönüş Değerleri : “Eşleşti/Eşleşmedi/Kayıt Bulunamadı”,
        /// </summary>
        public string TeletipStatus { get; set; }
        
        /// <summary>
        ///  TeletipStatusId, // 1 (Eşleşti), 2 (Eşleşmedi), 3 (Kayıt Bulunamadı)
        /// </summary>
        public int? TeletipStatusId { get; set; }
        public string WadoStatus { get; set; }
        public int WadoStatusId { get; set; }
        public string MedulaStatus { get; set; }
        public int MedulaStatusId { get; set; }
        public string MedulaInstitutionId { get; set; }
        public string SutCode { get; set; }
        public DateTime? LastMedulaSendDate { get; set; }
        public string MedulaResponseCode { get; set; }
        public string MedulaResponseMessage { get; set; }
        public string ReportStatus { get; set; }
        public int ReportStatusId { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public DateTime? PerformedDate { get; set; }
        public string Error { get; set; }


    }
}
