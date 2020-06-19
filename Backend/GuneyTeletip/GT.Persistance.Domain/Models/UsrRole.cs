using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain.Models
{
    public partial class UsrRole
    {
        public long Pk { get; set; }
        public string Name { get; set; }

        public virtual UsrUserRole UsrUserRole { get; set; }
    }
}
