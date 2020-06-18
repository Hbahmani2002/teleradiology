using GT.DataService.Implementation;
using GT.DataService.Model;
using GT.Repository.Models.Filter;
using GT.SERVICE;
using GT.UTILS.GRID;
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
        public void Save()
        {
            UserView model = new UserView();
            model.UserName = "baskaTestUserName";
            model.Name = "baskaTestName";
            model.Surname = "baskaTestSurname";
            model.EmailAdress = "baskaTest@test.com";
            var list = service.Save(model);
        }

        [Test]
        public void Delete()
        {
            var list = service.Delete(1);
        }
        [Test]
        public void GetByID()
        {
            var item = service.GetByID(2);
        }

        [Test]
        public void GetRolList()
        {
             var list = service.GetRolList();
        }

        [Test]
        public void GetRoleByID()
        {
            var roleID = service.GetRoleByID(2);
        }
        [Test]
        public void SaveRol()
        {
            var list = service.SaveRol(2,1);
        }
    }
}
