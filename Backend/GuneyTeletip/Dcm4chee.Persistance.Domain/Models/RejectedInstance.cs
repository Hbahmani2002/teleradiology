using System;
using System.Collections.Generic;

namespace Dcm4chee.Persistance.Domain.Models
{
    public partial class RejectedInstance
    {
        public long Pk { get; set; }
        public DateTime CreatedTime { get; set; }
        public string SeriesIuid { get; set; }
        public string SopCuid { get; set; }
        public string SopIuid { get; set; }
        public string StudyIuid { get; set; }
        public long? RejectCodeFk { get; set; }

        public virtual Code RejectCodeFkNavigation { get; set; }
    }
}
