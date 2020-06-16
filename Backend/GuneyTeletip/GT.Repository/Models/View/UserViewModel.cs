﻿using MEDLIFE.UTILS.GRID;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT.Repository.Models.View
{
    public class UserViewModel
    {
        [DataEntityID]
        public long Pk { get; set; }
        public string EmailAdress { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Surname { get; set; }
        public DateTime? TimeCreated { get; set; }
        public DateTime? TimeDelete { get; set; }
        public long UserFk { get; set; }
        public string UserName { get; set; }
        public long? UserFkLastModfiead { get; set; }
        public short? RecordType { get; set; }
        public string RoleName { get; set; }
    }
}