﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GT.DataService.Model
{
    public class JobViewFilter
    {
        public long[] JOBIDList { get; set; }
        public DateTime? BasTarih { get; set; }
        public DateTime? BitTarih { get; set; }
        public long EnumType { get; set; }
    }
}
