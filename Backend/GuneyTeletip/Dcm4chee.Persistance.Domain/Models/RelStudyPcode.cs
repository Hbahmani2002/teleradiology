using System;
using System.Collections.Generic;

namespace Dcm4chee.Persistance.Domain.Models
{
    public partial class RelStudyPcode
    {
        public long StudyFk { get; set; }
        public long PcodeFk { get; set; }

        public virtual Code PcodeFkNavigation { get; set; }
        public virtual Study StudyFkNavigation { get; set; }
    }
}
