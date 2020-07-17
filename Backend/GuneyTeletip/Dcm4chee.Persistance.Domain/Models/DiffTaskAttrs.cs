using System;
using System.Collections.Generic;

namespace Dcm4chee.Persistance.Domain.Models
{
    public partial class DiffTaskAttrs
    {
        public long DiffTaskFk { get; set; }
        public long DicomattrsFk { get; set; }

        public virtual Dicomattrs DicomattrsFkNavigation { get; set; }
        public virtual DiffTask DiffTaskFkNavigation { get; set; }
    }
}
