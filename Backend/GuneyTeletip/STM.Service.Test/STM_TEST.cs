using NUnit.Framework;
using STM.Service.Model;
using Teletip.SorgulamaServis;

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
            //var tokenProvider =new TokenProvider(TokenProvider.ServerAddress,)
            var token = new STMToken();
            var service = new STMService(token,STMService.BASEADDRESS);
            //service.GetDailyStudyList();
            
        }
    }
}