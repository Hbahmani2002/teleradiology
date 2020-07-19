using Dcm4chee.DataService;
using Dcm4chee.DataService.Models;
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
            Gridable<DcmViewFilter> gri = new Gridable<DcmViewFilter>();
            DcmViewFilter filter = new DcmViewFilter();
            gri.Filter = filter;
            var list = service.Query(gri);
        }
    }
}
