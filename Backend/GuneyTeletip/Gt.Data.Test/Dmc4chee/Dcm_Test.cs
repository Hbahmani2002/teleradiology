using Dcm4chee.DataService;
using Dcm4chee.DataService.Model;
using GT.SERVICE;
using GT.UTILS.GRID;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gt.Data.Test.Dmc4chee
{
    public class Dcm_Test
    {
        [SetUp]
        public void Setup()
        {
        }
        DcmDataService service = new DcmDataService(new BussinessContext(new UserContextModel(1)));
        [Test]
        public void GetGetorderStatusList()
        {
            ProtekOracleFilter filter = new ProtekOracleFilter();
            //filter.ModalityList =new string[1] { 
            //    "CT"
            //};
            filter.BasTar = new DateTime(2020, 08, 07);
            filter.BitTar = new DateTime(2020, 08, 08);
            var list = service.Query(filter,10);
        }
    }
}
