using System;
using System.Collections.Generic;
using System.Text;
using static GT.Repository.Conditions.InfStudyConditionFilter;

namespace GT.DataService.Model
{
    public class InfStudyFilter
    {
        public long[] HastaneIDList { get; set; }
        public DateTime? BasTarih { get; set; }
        public DateTime? BitTarih { get; set; }
        public string Modalite { get; set; }
        public string EslesmeDurumu { get; set; }
        public string[] TCList { get; set; }
        public string[] AccessionNumberList { get; set; }
        public KosEnumType? KosEnum { get; set; }
        public bool? KosWaitHour { get; set; }
        public string StudyInstanceUID { get; set; }
        public string PatientID { get; set; }
    }
}
