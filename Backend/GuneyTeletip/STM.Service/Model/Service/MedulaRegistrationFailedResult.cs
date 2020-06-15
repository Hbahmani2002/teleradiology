using System;

namespace Teletip.SorgulamaServis
{
    public class MedulaRegistrationFailedResult
    {
        public string AccessionNuber { get; set; }

        public DateTime LastMedulaSendDate { get; set; }

        public int NumberOfAttempt { get; set; }

        public string LastMedulaResponseCode { get; set; }

        public string LastMedulaResponseMessage { get; set; }

    }

}
