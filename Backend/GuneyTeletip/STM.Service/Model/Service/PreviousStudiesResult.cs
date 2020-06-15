using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teletip.SorgulamaServis
{
    public class PreviousStudiesResult
    {
        public string OrderId { get; set; }
        public string InstitutionName { get; set; }
        public string SKRS { get; set; }
        public string AccessionNumber { get; set; }
        public DateTime ScheduleDate { get; set; }
        public DateTime PerformedDate { get; set; }
        public string RequestedProcedureDesciption { get; set; }
        public bool IsStudyExist { get; set; }
        public bool IsReportExist { get; set; }

    }
}
