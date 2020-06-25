using Gt.PERSISTANCE;
using GT.DataService.Model;
using GT.Persistance.Domain.Models;
using GT.Repository.Conditions;
using GT.Repository.Implementation;
using GT.Repository.Models.View;
using GT.SERVICE;
using GT.UTILS.GRID;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT.DataService.Implementation
{
    public class RolDataService : BaseService
    {
        AbstractWorkspace _Workspace;
        RoleRepository roleRepository;
        RolePermissionRepository rolePermissionRepository;
        public RolDataService(IBussinessContext context) : base(context)
        {
            _Workspace = GTWorkspaceFactory.Create(true);
            roleRepository = new RoleRepository(_Workspace);
            rolePermissionRepository = new RolePermissionRepository(_Workspace);
        }

        public PagingResult<RoleViewModel> GetRoleList(Gridable<RoleViewFilter> parms)
        {
            if (parms == null)
            {
                parms = new Gridable<RoleViewFilter>();
            }
            if (parms.Filter == null)
            {
                parms.Filter = new RoleViewFilter();
            }
            var  r= new RolConditionFilter
            {
                ID=parms.Filter.ID,
                RolName=parms.Filter.RoleName
            };
            return roleRepository.Query(r).GetGridQuery(parms);
        }

        public long Save(long? id, string rolAdi, string aciklama)
        {
            var rol = new UsrRole();
            if (id.HasValue)
            {
                rol = roleRepository.GetByID(id.Value);
                rol.TimeModified = DateTime.Now;
                rol.FkUserModified = Context == null ? (long?)null : Context.UserInfo.UserIDCurrent;
                roleRepository.Update(rol);
            }
            else
            {
                rol.TimeCreated = DateTime.Now;
                rol.FkUserCreated = Context == null ? (long?)null : Context.UserInfo.UserIDCurrent;
                roleRepository.Add(rol);
            }
            rol.Description = aciklama;
            rol.Name = rolAdi;
            _Workspace.CommitChanges();
            return rol.Pk;
        }

        public int Delete(long id)
        {
            var rol = roleRepository.GetByID(id);
            if (rol == null)
                throw new Exception("RolID null olamaz. RolID"+id);
            var permissionList = rolePermissionRepository.GetByRoleID(id);
            foreach (var item in permissionList)
            {
                rolePermissionRepository.Delete(item);
            }
            _Workspace.CommitChanges();
            return 1;
        }
        
        public List<PermissionViewModel> GetPermissionList()
        {
            return null;
        }

        public List<PermissionViewModel> GetPermissionListByRoleID(long roleID)
        {
            return null;
        }

        public int SavePermission(long roleID, long[] permisiionIDList)
        {
            return 1;
        }
    }
}
