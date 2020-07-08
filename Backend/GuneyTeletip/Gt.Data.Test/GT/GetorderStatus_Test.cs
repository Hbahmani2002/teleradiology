using GT.DataService.Implementation;
using GT.DataService.Model;
using GT.SERVICE;
using GT.UTILS.GRID;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gt.Data.Test.GT
{
    public class GetorderStatus_Test
    {
        [SetUp]
        public void Setup()
        {
        }
        GetorderStatusDataService service = new GetorderStatusDataService(new BussinessContext(new UserContextModel(1)));
        [Test]
        public void GetGetorderStatusList()
        {
            var grid = new Gridable<GetorderStatusViewFilter>();

            var filter = new GetorderStatusViewFilter();
            grid.Filter = filter;
            var list = service.GetGetorderStatusList(grid);
        }
    }
}
