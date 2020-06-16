using GT.DataService.Model;
using GT.Persistance.Domain.Models;
using GT.Repository.Conditions;
using GT.Repository.Implementation;
using GT.Repository.Models.Filter;
using GT.Repository.Models.View;
using MEDLIFE.PERSISTANCE;
using MEDLIFE.SERVICE;
using MEDLIFE.UTILS.GRID;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT.DataService.Implementation
{
    public class UserDataService : BaseService
    {
        AbstractWorkspace _Workspace;
        UserLoginRepository userLoginRepository;
        public UserDataService(IBussinessContext context) : base(context)
        {
            _Workspace = WorkspaceFactory.Create(true);
            userLoginRepository = new UserLoginRepository(_Workspace);
        }

        public PagingResult<UserViewModel> GetUserList(Gridable<UserViewFilter> parms)
        {
            if (parms == null)
            {
                parms = new Gridable<UserViewFilter>();
            }
            if (parms.Filter == null)
            {
                parms.Filter = new UserViewFilter();
            }
            var u = new UserConditionFilter
            {
                EmailAdress=parms.Filter.EmailAdress,
                Name=parms.Filter.Name,
                Password=parms.Filter.Password,
                Pk=parms.Filter.Pk,
                RecordType=parms.Filter.RecordType,
                Surname=parms.Filter.Surname,
                TimeCreated=parms.Filter.TimeCreated,
                TimeDelete=parms.Filter.TimeDelete,
                UserFk=parms.Filter.UserFk,
                UserFkLastModfiead=parms.Filter.UserFkLastModfiead,
                UserName=parms.Filter.UserName
            };
            return userLoginRepository.Query(u).GetGridQuery(parms);
        }

        public int Save(UserView model)
        {
            var userLogin = new UsrUserLogin();
            if (model.Pk == null)
            {
                userLoginRepository.Add(userLogin);
            }
            else
            {
                userLogin = userLoginRepository.GetByID(model.Pk);
                userLoginRepository.Update(userLogin);
            }
            userLogin.EmailAdress = model.EmailAdress;
            userLogin.Name = model.Name;
            userLogin.Password = model.Password;
            userLogin.Surname = model.Surname;
            userLogin.UserName = model.UserName;
           // userLogin.
            return 0;
        }
    }
}
