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

namespace GT.DataService.Implementation
{
    public class UserDataService : BaseService
    {
        AbstractWorkspace _Workspace;
        UserCompositeRepository userCompositeRepository;
        UserLoginRepository userLoginRepository;
        TenantRepository tenantRepository;

        KurumRepository kurumRepository;

        UserRoleRepository userRoleRepository;
        RoleRepository roleRepository;
        UserTenantRepository userTenantRepository;
        UserTenantCompositeRepository userTenantCompositeRepository;
        UserRoleCompositeRepository userRoleCompositeRepository;
        public UserDataService(IBussinessContext context) : base(context)
        {
            _Workspace = GTWorkspaceFactory.Create(true);
            userCompositeRepository = new UserCompositeRepository(_Workspace);
            userLoginRepository = new UserLoginRepository(_Workspace);
            tenantRepository = new TenantRepository(_Workspace);

            kurumRepository = new KurumRepository(_Workspace);

            userRoleRepository = new UserRoleRepository(_Workspace);
            roleRepository = new RoleRepository(_Workspace);
            userTenantRepository = new UserTenantRepository(_Workspace);
            userTenantCompositeRepository = new UserTenantCompositeRepository(_Workspace);
            userRoleCompositeRepository = new UserRoleCompositeRepository(_Workspace);
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
            var r = new RolConditionFilter
            {
                RolName=parms.Filter.RolName,
                ID=parms.Filter.RolID
            };
            var roleList = userCompositeRepository.RoleList();
            var userList = userCompositeRepository.Query(u, r).Select(o => new UserViewModel
            {
                RolIDList = roleList.Where(x => x.UserID == o.ID).Select(x => x.RoleID).ToArray(),
                RolNameList = roleList.Where(x => x.UserID == o.ID).Select(x => x.RoleName).ToArray(),
                EmailAdress = o.EmailAdress,
                ID = o.ID,
                Name = o.Name,
                RecordStatus = o.RecordStatus,
                Surname = o.Surname,
                TimeCreated = o.TimeCreated,
                TimeModified = o.TimeModified,
                UserIDCreated = o.UserIDCreated,
                UserIDModified = o.UserIDModified,
                UserName = o.UserName
            });
            return userList.GetGridQuery(parms);
        }

        public int Save(UserView model)
        {
            var userLogin = new UsrUserLogin();
            if (model.ID == null)
            {
                userLogin.FkUserModified = Context == null ? (long?)null : Context.UserInfo.UserIDCurrent;
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
                userLogin.FkUserModified = Context == null ? (long?)null : Context.UserInfo.UserIDCurrent;
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
            if (user == null)
            {
                throw new Exception("Kullanıcı veya kullanıcı Rolü bulunamadı");
            }
            userLoginRepository.Delete(user);
            if(userRol != null)
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

        public List<UserRoleViewModel> GetRoleByID(long userID)
        {
            var rolIDList = userRoleRepository.GetRolListByUserID(userID).Select(x => x.FkRole).ToArray();
            var ur = new UserRolConditionFilter { UserID= userID };
            var r = new RolConditionFilter
            {
                IDList= rolIDList
            };
            var userRol = userRoleCompositeRepository.Query(ur,r).ToList();
            return userRol;
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
            var tenantUserIDList = userTenantRepository.GetTenantIDByUserID(Context.UserInfo.UserIDCurrent).Select(o => o.Pk).ToArray();
            var t = new TenantConditionFilter
            {
                TenantIDList= tenantUserIDList
            };
            return tenantRepository.Query(t).ToList();
        }
        
        //public List<KurumViewModel> GetKurumList()
        //{
        //    //var tenantUserIDList = userTenantRepository.GetTenantIDByUserID(Context.UserInfo.UserIDCurrent).Select(o => o.Pk).ToArray();
        //    //var t = new KurumlarConditionFilter
        //    //{
        //    //    KurumlarIDList = tenantUserIDList
        //    //};
        //    //return kurumRepository.Query(t).ToList();
        //}
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
