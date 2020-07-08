using System;
using System.Collections.Generic;
using System.Text;

namespace GT.DataService.Model
{
    public class GetorderStatusViewFilter
    {
        public DateTime? BasTar { get; set; }
        public DateTime? BitTar { get; set; }
        public long[] HastaneIDList { get; set; }
        public long[] TeletipStatusIDList { get; set; }
    }
}
