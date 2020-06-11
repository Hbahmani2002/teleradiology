using GT.DataService.Implementation;
using GT.Repository.Models.Filter;
using MEDLIFE.SERVICE;
using MEDLIFE.UTILS.GRID;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT.Test.GT
{
    public class Tenat_test
    {
        [SetUp]
        public void Setup()
        {
        }

        TenatDataService service = new TenatDataService(new BussinessContext(new UserContextModel(1, null)));
        [Test]
        public void Test1()
        {
            Gridable<TenatViewFilter> gri = new Gridable<TenatViewFilter>();
            TenatViewFilter filter = new TenatViewFilter();
            gri.Filter = filter;
            var list = service.GetTenatList(gri);
        }
    }
}
