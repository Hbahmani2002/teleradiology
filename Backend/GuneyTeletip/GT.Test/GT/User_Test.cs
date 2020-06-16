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
    public class User_test
    {
        [SetUp]
        public void Setup()
        {
        }
        UserDataService service = new UserDataService(new BussinessContext(new UserContextModel(1)));
        [Test]
        public void GetUserList()
        {
            Gridable<UserViewFilter> gri = new Gridable<UserViewFilter>();
            UserViewFilter filter = new UserViewFilter();
            gri.Filter = filter;
            var list = service.GetUserList(gri);
        }
    }
}
