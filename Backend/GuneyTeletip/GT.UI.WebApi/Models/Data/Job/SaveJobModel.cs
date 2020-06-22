using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GT.UI.WebApi.Models.Data.Job
{
    public class SaveJobModel
    {
        public DateTime basTar { get; set; }
        public DateTime bitTar { get; set; }
        public string tip { get; set; } 
        public long basariliSayisi { get; set; } 
        public long basarisizSayisi { get; set; }
    }
}
