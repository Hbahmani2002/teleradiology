using GT.DataService.Model;
using GT.Persistance.Domain.Models;
using GT.Repository.Conditions;
using GT.Repository.Implementation;
using GT.Repository.Implementation.Composite;
using GT.Repository.Models.Filter;
using GT.Repository.Models.View;
using MEDLIFE.PERSISTANCE;
using MEDLIFE.SERVICE;
using MEDLIFE.UTILS.GRID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static GT.Repository.Conditions.RoleCondition;

namespace GT.DataService.Implementation
{
    public class UserDataService : BaseService
    {
        AbstractWorkspace _Workspace;
        UserCompositeRepository userCompositeRepository;
        UserLoginRepository userLoginRepository;
        public UserDataService(IBussinessContext context) : base(context)
        {
            _Workspace = WorkspaceFactory.Create(true);
            userCompositeRepository = new UserCompositeRepository(_Workspace);
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
                RecordState=parms.Filter.RecordType,
                Surname=parms.Filter.Surname,
                TimeCreated=parms.Filter.TimeCreated,
                TimeModified=parms.Filter.TimeDelete,
                FkUserCreated=parms.Filter.UserFk,
                FkUserModified=parms.Filter.UserFkLastModfiead,
                UserName=parms.Filter.UserName
            };
            var r = new RoleConditionFilter
            {
                RoleName=parms.Filter.RolName,
                ID=parms.Filter.RolID
            };
            return userCompositeRepository.Query(u,r)
                .GetGridQuery(parms);
        }

        public int Save(UserView model)
        {
            var userLogin = new UsrUserLogin();
            if (model.Pk == null)
            {
                userLogin.FkUserModified = Context.UserInfo.UserIDCurrent;
                userLogin.TimeCreated = DateTime.Now;
                userLoginRepository.Add(userLogin);
            }
            else
            {
                userLogin = userLoginRepository.GetByID(model.Pk);
                userLogin.TimeModified = DateTime.Now;
                userLogin.FkUserModified = Context.UserInfo.UserIDCurrent;
                userLoginRepository.Update(userLogin);
            }
            userLogin.EmailAdress = model.EmailAdress;
            userLogin.Name = model.Name;
            userLogin.Password = model.Password;
            userLogin.Surname = model.Surname;
            userLogin.UserName = model.UserName;
            userLogin.RecordState = 1;
            _Workspace.CommitChanges();
            return 1;
        }

        public UserViewModel GetByID(long userID)
        {
            //var user = userLoginRepository.GetByID(userID);
            //var item = new UserViewModel
            //{
            //    EmailAdress=user.EmailAdress,
            //    FkUserCreated=user.FkUserCreated,
            //    FkUserModified=user.FkUserModified,
            //    Name=user.Name,
            //    Password=user.Password,
            //    Pk=user.Pk,
            //    RecordState=user.RecordState,
            //    Surname=user.Surname,
            //    TimeCreated=user.TimeCreated,
            //    TimeModified=user.TimeModified,
            //    UserName=user.UserName
            //};
            //  return item;
            return null;
        }
        public int Delete(long userID)
        {
            //var user = userLoginRepository.GetByID(userID);
            //var userRol = userRoleRepository.GetByUserID(userID);
            ////Kullanıcının rolü olmak zorunda mı??
            ////if (user == null && userRol==null)
            ////{
            ////    throw new Exception("Kullanıcı veya kullanıcı Rolü bulunamadı");
            ////}
            //userLoginRepository.Delete(user);
            //userRoleRepository.Delete(userRol);
            //_Workspace.CommitChanges();
            return 0;
        }

        public List<RoleViewModel> GetRolList()
        {
            //return roleRepository.Query().Select(o => new RoleViewModel
            //{
            //    RoleName=o.UsrRoleAd,
            //    RolePK=o.Pk
            //}).ToList();
            return null;
        }

        public int GetRoleByID(long userID)
        {
            // var user = userRoleRepository.GetByUserID(pk);
            return 1;
        }

        public int SaveRol(long userID, long roleID)
        {
            return 1;
        }

        public List<TenantViewModel> GetTenantList()
        {
            //var t = new TenantConditionFilter
            //{

            //};
            //return tenatRepository.Query(t).ToList();
            return null;
        }
        public int SaveTenant(long userID, long[] tenantIDList)
        {
            return 1;
        }
        public int GetTenantByID(long userID)
        {
            return 1;
        }
    }
}
