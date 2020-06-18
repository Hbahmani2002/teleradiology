using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain.Models
{
    public partial class UsrUserLogin
    {
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
        public short? RecordState { get; set; }

        public virtual UsrUserRole UsrUserRole { get; set; }
    }
}
