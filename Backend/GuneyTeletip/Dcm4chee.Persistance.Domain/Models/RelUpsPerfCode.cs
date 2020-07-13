using System;
using System.Collections.Generic;

namespace Dcm4chee.Persistance.Domain.Models
{
    public partial class RelUpsPerfCode
    {
        public long UpsFk { get; set; }
        public long PerfCodeFk { get; set; }

        public virtual Code PerfCodeFkNavigation { get; set; }
        public virtual Ups UpsFkNavigation { get; set; }
    }
}
