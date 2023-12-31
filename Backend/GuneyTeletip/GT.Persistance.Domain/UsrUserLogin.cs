﻿using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain
{
    public partial class UsrUserLogin
    {
        public UsrUserLogin()
        {
            UsrUserRole = new HashSet<UsrUserRole>();
        }

        public long Pk { get; set; }
        public string EmailAdress { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Surname { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime? TimeModified { get; set; }
        public long FkUserCreated { get; set; }
        public string UserName { get; set; }
        public long? FkUserModified { get; set; }
        public long? RecordStatus { get; set; }

        public virtual ICollection<UsrUserRole> UsrUserRole { get; set; }
    }
}
