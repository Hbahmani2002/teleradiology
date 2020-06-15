using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain.Models
{
    public partial class UsrUserRole
    {
        public long Pk { get; set; }
        public long UserFk { get; set; }
        public long RoleFk { get; set; }

        public virtual UsrRole RoleFkNavigation { get; set; }
        public virtual UsrUserLogin UserFkNavigation { get; set; }
    }
}
