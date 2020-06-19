using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GT.UI.WebApi.Models.RoleModel
{
    public class SavePermissionModel
    {
        public long RoleID { get; set; }
        public long[] PermissionIDList { get; set; }
    }
}
