using System;
using System.Collections.Generic;
using System.Text;

namespace GT.Repository.Models.View
{
    public class UserLoginViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string[] RoleList { get; set; }
        public long UserID { get; set; }
    }
}
