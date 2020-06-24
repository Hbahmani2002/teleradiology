using GT.UTILS.GRID;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT.Repository.Models.View
{
    public class JobViewmodel
    {
        public DateTime BasTarih { get; set; }
        public DateTime BitTarih { get; set; }
        [DataEntityID]
        public string Tip { get; set; }
        public long BasariliSayisi { get; set; }
        public long BasarisizSayisi { get; set; }

    }
}
