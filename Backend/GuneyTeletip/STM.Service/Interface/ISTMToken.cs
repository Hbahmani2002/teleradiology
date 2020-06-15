//using IdentityModel.Client;
using System;

namespace Teletip.SorgulamaServis
{
    public interface ISTMToken
    {
        string TokenValue { get; set; }
        DateTime TokenDate { get; set; }
    }
}