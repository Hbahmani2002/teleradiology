using GT.UTILS.GRID;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT.Repository.Models.View
{
    public class RoleViewModel
    {
        [DataEntityID]
        public long RoleID { get; set; }
        public string RoleName { get; set; }
    }
}
