using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain.Models
{
    public partial class AppRolePermission
    {
        public long Pk { get; set; }
        public long? FkRoleId { get; set; }
        public long? FkPermissionId { get; set; }
    }
}
