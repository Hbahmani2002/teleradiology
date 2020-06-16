using System;
using System.Collections.Generic;
using System.Text;

namespace GT.DataService.Model
{
    public class UserUIModel
    {
        public long Pk { get; set; }
        public string EmailAdress { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
    }
}
