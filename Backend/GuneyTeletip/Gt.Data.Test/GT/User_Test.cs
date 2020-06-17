using GT.DataService.Implementation;
using GT.DataService.Model;
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
            var gri = new Gridable<UserViewFilter>();
            var filter = new UserViewFilter();
            gri.Filter = filter;
            var list = service.GetUserList(gri);
        }

        [Test]
        public void GetUserListAndRole()
        {
            var gri = new Gridable<UserViewFilter>();
            var filter = new UserViewFilter();
            gri.Filter = filter;
           // var list = service.GetUserListAndRole(gri);
        }

        [Test]
        public void Save()
        {
            UserView model = new UserView();
            model.UserName = "testUserName";
            model.Pk = 1;
            model.Name = "testName";
            model.Surname = "testSurname";
            model.EmailAdress = "test@test.com";
            var list = service.Save(model);
        }

        [Test]
        public void Delete()
        {
            var list = service.Delete(1);
        }
    }
}
