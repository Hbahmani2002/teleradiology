using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain.Models
{
    public partial class UsrUserRole
    {
        public long Pk { get; set; }
        public long FkUser { get; set; }
        public long FkRole { get; set; }

        public virtual UsrRole FkRoleNavigation { get; set; }
        public virtual UsrUserLogin FkUserNavigation { get; set; }
    }
}
