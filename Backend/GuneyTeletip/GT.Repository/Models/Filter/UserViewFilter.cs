using System;
using System.Collections.Generic;
using System.Text;

namespace GT.Repository.Models.Filter
{
    public class UserViewFilter
    {
        public long? ID { get; set; }
        public string EmailAdress { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string RolName { get; set; }
        public long? RolID { get; set; }
        public string UserName { get; set; }
    }
}
