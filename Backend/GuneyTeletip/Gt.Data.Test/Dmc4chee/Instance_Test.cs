using Dcm4chee.DataService;
using GT.SERVICE;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gt.Data.Test.Dmc4chee
{
    public class Instance_Test
    {
        [SetUp]
        public void Setup()
        {
        }
        InstanceDataService service = new InstanceDataService(new BussinessContext(new UserContextModel(1)));
        [Test]
        public void GetGetorderStatusList()
        {
            var list = service.Query();
        }
    }
}
