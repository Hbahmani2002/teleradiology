using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain.Models
{
    public partial class UsrUserLogin
    {
        public UsrUserLogin()
        {
            UsrUserRole = new HashSet<UsrUserRole>();
        }

        public string EmailAdress { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public long Pk { get; set; }
        public string Surname { get; set; }
        public DateTime? TimeCreated { get; set; }
        public DateTime? TimeDelete { get; set; }
        public long UserFk { get; set; }
        public string UserName { get; set; }
        public long UserFkLastModfiead { get; set; }
        public short? RecordType { get; set; }

        public virtual ICollection<UsrUserRole> UsrUserRole { get; set; }
    }
}
