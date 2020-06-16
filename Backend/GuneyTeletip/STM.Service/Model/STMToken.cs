using System;
using System.Collections.Generic;
using System.Text;
using Teletip.SorgulamaServis;

namespace STM.Service.Model
{
    public class STMToken : ISTMToken
    {
        public string TokenValue { get; set; }
        public DateTime TokenDate { get; set; }
    }
}
