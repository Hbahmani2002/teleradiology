using Gt.PERSISTANCE;
using GT.DataService.Model;
using GT.Persistance.Domain.Models;
using GT.Repository.Conditions;
using GT.Repository.Implementation;
using GT.Repository.Implementation.Composite;
using GT.Repository.Models.Filter;
using GT.Repository.Models.View;
using GT.SERVICE;
using GT.UTILS.GRID;
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
        TenantRepository tenantRepository;
        UserRoleRepository userRoleRepository;
        RoleRepository roleRepository;
        UserTenantRepository userTenantRepository;
        UserTenantCompositeRepository userTenantCompositeRepository;
        public UserDataService(IBussinessContext context) : base(context)
        {
            _Workspace = GTWorkspaceFactory.Create(true);
            userCompositeRepository = new UserCompositeRepository(_Workspace);
            userLoginRepository = new UserLoginRepository(_Workspace);
            tenantRepository = new TenantRepository(_Workspace);
            userRoleRepository = new UserRoleRepository(_Workspace);
            roleRepository = new RoleRepository(_Workspace);
            userTenantRepository = new UserTenantRepository(_Workspace);
            userTenantCompositeRepository = new UserTenantCompositeRepository(_Workspace);
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
                ID=parms.Filter.ID,
                Surname=parms.Filter.Surname,
                UserName=parms.Filter.UserName
            };
            var r = new RoleConditionFilter
            {
                RoleName=parms.Filter.RolName,
                ID=parms.Filter.RolID
            };
            return userCompositeRepository.Query(u,r).GetGridQuery(parms);
        }

        public int Save(UserView model)
        {
            var userLogin = new UsrUserLogin();
            if (model.ID == null)
            {
                userLogin.FkUserModified = Context.UserInfo.UserIDCurrent;
                userLogin.TimeCreated = DateTime.Now;
                userLoginRepository.Add(userLogin);
            }
            else
            {
                userLogin = userLoginRepository.GetByID(model.ID.Value);
                if (model.ID == null)
                {
                    throw new Exception("User bulunamadı. UserID:" + model.ID);
                }
                userLogin.TimeModified = DateTime.Now;
                userLogin.FkUserModified = Context.UserInfo.UserIDCurrent;
                userLoginRepository.Update(userLogin);
            }
            userLogin.EmailAdress = model.EmailAdress;
            userLogin.Name = model.Name;
            userLogin.Password = model.Password;
            userLogin.Surname = model.Surname;
            userLogin.UserName = model.UserName;
            userLogin.RecordStatus = model.RecordState;
            _Workspace.CommitChanges();
            return 1;
        }

        public UserView GetByID(long userID)
        {
            var user = userLoginRepository.GetByID(userID);
            if (user == null)
            {
                throw new Exception("User bulunamadı. UserID:"+userID);
            }
            var item = new UserView
            {
                EmailAdress = user.EmailAdress,
                Name = user.Name,
                ID = user.Pk,
                RecordState = user.RecordStatus,
                Surname = user.Surname,
                UserName = user.UserName
            };
            return item;
        }
        public int Delete(long userID)
        {
            var user = userLoginRepository.GetByID(userID);
            var userRol = userRoleRepository.GetByUserID(userID);
            if (user == null && userRol == null)
            {
                throw new Exception("Kullanıcı veya kullanıcı Rolü bulunamadı");
            }
            userLoginRepository.Delete(user);
            userRoleRepository.Delete(userRol);
            _Workspace.CommitChanges();
            return 0;
        }

        public List<RoleViewModel> GetRolList()
        {
            var list = roleRepository.Query().Select(o => new RoleViewModel
            {
                RoleName = o.Name,
                RoleID = o.Pk
            });
            return list.ToList();
        }

        public RoleViewModel GetRoleByID(long userID)
        {
            var userRol = userRoleRepository.GetByUserID(userID);
            var rol = roleRepository.GetByID(userRol.FkRole);
            if (userRol == null || rol==null)
            {
                throw new Exception("Kullanıcı veya kullanıcı rolü bulunmamaktadır");
            }
            var item = new RoleViewModel
            {
                RoleID= rol.Pk,
                RoleName=rol.Name
            };
            return item;
        }

        public int SaveRol(long userID, long roleID)
        {
            var user = userRoleRepository.GetByUserID(userID);
            if (user == null)
            {
                user = new UsrUserRole();
                user.FkRole = roleID;
                user.FkUser = userID;
                userRoleRepository.Add(user);
            }
            else
            {
                user.FkRole = roleID;
                userRoleRepository.Update(user);
            }
            _Workspace.CommitChanges();
            return 1;
        }

        public List<TenantViewModel> GetTenantList()
        {
            var t = new TenantConditionFilter
            {

            };
            return tenantRepository.Query(t).ToList();
        }
        public int SaveTenant(long userID, long[] tenantIDList)
        {
            var userTenantIDList = userTenantRepository.GetTenantIDByUserID(userID).Select(x => x.FkTenant).ToList();
            foreach (var tenantID in tenantIDList)
            {
                var tenantVarMi = false;
                foreach (var userTenantID in userTenantIDList)
                {
                    if(tenantID== userTenantID)
                    {
                        tenantVarMi = true;
                        break;
                    }
                }
                if (!tenantVarMi)
                {
                    var yeniTenant = new UsrUserTenant();
                    yeniTenant.FkUser = userID;
                    yeniTenant.FkTenant = tenantID;
                    yeniTenant.TimeCreated = DateTime.Now;
                    yeniTenant.FkUserCreated = Context.UserInfo.UserIDCurrent;
                    userTenantRepository.Add(yeniTenant);
                    _Workspace.CommitChanges();
                }
            }
            return 1;
        }
        public List<TenantViewModel> GetTenantListByUserID(long userID)
        {
            return userTenantCompositeRepository.Query(userID).ToList();
        }
    }
}
