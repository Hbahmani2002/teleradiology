using GT.UTILS.GRID;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT.Repository.Models.View
{
    public class UserViewModel : BaseTableViewModel
    {
        [DataEntityID]
        public long ID { get; set; }
        public string EmailAdress { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string[] RolNameList { get; set; }
        public long[] RolIDList { get; set; }
        public string UserName { get; set; }
    }
}
