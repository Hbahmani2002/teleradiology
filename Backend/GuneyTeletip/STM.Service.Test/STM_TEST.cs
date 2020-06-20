using NUnit.Framework;
using Teletip.SorgulamaServis;
using STM.Service.Test;
using System.Diagnostics.CodeAnalysis;
using System;
using GT.Core.Settings;

namespace STM.Service.Test
{
    public class STM_TEST
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            /*
            ClientPassword=HbPatT!180430
            UserName:protek_hbys@teletip.saglik.gov.tr
            ResponsePassword:1234Aasd?
             */



            int startGun = 0;
            int startAy = 0;
            int startYıl = 0;
            int finGun = 0;
            int finAy = 0;
            int finYıl = 0;

            startGun = 10;
            startAy = 05;
            startYıl = DateTime.Now.Year;

            finGun = DateTime.Now.Day;
            finAy = DateTime.Now.Month;
            finYıl = DateTime.Now.Year;

            DateTime StartDateTime;
            DateTime EndDateTime;


            StartDateTime = new DateTime(startYıl, startAy, startGun, 0, 0, 0);
            EndDateTime = new DateTime(finYıl, finAy, finGun, 0, 0, 0);


            var stmSettings = AppSettings.GetCurrent().STM;
            ISTMTokenProvider tk = new STMTokenProvider(stmSettings.BASEADDRESS, stmSettings.userTokenName, stmSettings.userTokenPassword, stmSettings.HBYS_PACS_ResourceOwnerClient, stmSettings.identityServerBaseUri);
            var stm_token = tk.GetToken();
            var service = new STMService(stm_token, stmSettings.BASEADDRESS);



            service.GetMedulaRegistrationFailedOrderList("11340028", "", StartDateTime, EndDateTime);
            service.GetMedulaRegistrationFailedOrderList("11340028", "", StartDateTime, EndDateTime);

            service.GetDailyStudyList(11340028, "", StartDateTime);
            service.GetDailyStudyList(11340028, "DX", StartDateTime);
            service.GetDailyStudyList(11340028, "", StartDateTime);

        }
    }
}