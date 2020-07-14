using System;
using System.Collections.Generic;

namespace Dcm4chee.Persistance.Domain.Models
{
    public partial class SoundexCode
    {
        public long Pk { get; set; }
        public string SxCodeValue { get; set; }
        public int SxPnCompPart { get; set; }
        public int SxPnComp { get; set; }
        public long PersonNameFk { get; set; }

        public virtual PersonName PersonNameFkNavigation { get; set; }
    }
}
