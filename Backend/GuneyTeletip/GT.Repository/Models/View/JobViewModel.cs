using GT.UTILS.GRID;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT.Repository.Models.View
{
    public class JobViewModel
    {
        [DataEntityID]
        public long ID { get; set; }
        public DateTime BasTarih { get; set; }
        public DateTime BitTarih { get; set; }
        public string Tip { get; set; }
        public long BasariliSayisi { get; set; }
        public long BasarisizSayisi { get; set; }
        public long? JobTypeID { get; set; }
    }
}
