using System;
using System.Collections.Generic;

namespace Dcm4chee.Persistance.Domain.Models
{
    public partial class IdSequence
    {
        public string Name { get; set; }
        public int NextValue { get; set; }
        public long? Version { get; set; }
    }
}
