using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GT.DataService.Implementation;
using GT.DataService.Model;
using GT.Repository.Models.Filter;
using GT.Repository.Models.View;
using GT.UI.WebApi.Implementation;
using GT.UI.WebApi.Models;
using GT.UI.WebApi.Models.RoleModel;
using GT.UI.WebApi.Models.UserModel;
using GT.UTILS.GRID;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GT.UI.WebApi.Controllers
{
    [ApiController]

    [Route("[controller]")]
    public class RoleController : AuthenticatedBaseController
    {

        [HttpPost]
        [Route("/Role/GetRoleList")]
        public ServiceResult<PagingResult<RolViewModel>> GetRoleList(Gridable<RoleViewFilter> parms)
        {
            var cx = GetBussinesContext();
            var service = new RolDataService(cx);
            return HttpMessageService.Ok(service.GetRoleList(parms));
        }

        [HttpPost]
        [Route("/Role/Save")]
        public ServiceResult<int> Save(SaveRoleModel model)
        {
            var cx = GetBussinesContext();
            var service = new RolDataService(cx);
            return HttpMessageService.Ok(service.Save(model.ID,model.RolAdi,model.GorunenAd,model.Aciklama));
        }

        [HttpPost]
        [Route("/Role/Delete")]
        public ServiceResult<int> Delete(RoleModel model)
        {
            var cx = GetBussinesContext();
            var service = new RolDataService(cx);
            return HttpMessageService.Ok(service.Delete(model.RolID));
        }

        [HttpPost]
        [Route("/Role/GetPermissionList")]
        public ServiceResult<List<PermissionViewModel>> GetPermissionList()
        {
            var cx = GetBussinesContext();
            var service = new RolDataService(cx);
            return HttpMessageService.Ok(service.GetPermissionList());
        }

        [HttpPost]
        [Route("/Role/GetPermissionListByRoleID")]
        public ServiceResult<List<int>> GetPermissionListByRoleID(RoleModel model)
        {
            var cx = GetBussinesContext();
            var service = new RolDataService(cx);
            return HttpMessageService.Ok(service.GetPermissionListByRoleID(model.RolID));
        }

        [HttpPost]
        [Route("/Role/SavePermission")]
        public ServiceResult<int> SavePermission(SavePermissionModel model)
        {
            var cx = GetBussinesContext();
            var service = new RolDataService(cx);
            return HttpMessageService.Ok(service.SavePermission(model.RoleID,model.PermissionIDList));
        }
    }
}
