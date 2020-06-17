using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GT.UI.WebApi.Models.UserModel
{
    public class SaveTenantUIModel
    {
        public long UserID { get; set; }
        public long[] TenantIDList { get; set; }
    }
}
