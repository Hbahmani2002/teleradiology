using Gt.PERSISTANCE;
using GT.DataService.Model;
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
        public RolDataService(IBussinessContext context) : base(context)
        {
            _Workspace = GTWorkspaceFactory.Create(true);
            roleRepository = new RoleRepository(_Workspace);
        }

        public PagingResult<RolViewModel> GetRoleList(Gridable<RoleViewFilter> parms)
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

        public int Save(long? id, string rolAdi, string gorünenAd, string aciklama)
        {
            return 1;
        }
        public int Delete(long id)
        {
            return 1;
        }
        
        public List<PermissionViewModel> GetPermissionList()
        {
            return null;
        }

        public List<int> GetPermissionListByRoleID(long roleID)
        {
            return null;
        }

        public int SavePermission(long roleID, long[] permisiionIDList)
        {
            return 1;
        }
    }
}
