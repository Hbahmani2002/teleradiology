using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GT.UI.WebApi.Models.RoleModel
{
    public class SaveRoleModel
    {
        public long? ID { get; set; }
        public string RolAdi{ get; set; }
        public string GorunenAd { get; set; }
        public string Aciklama { get; set; }
    }
}
