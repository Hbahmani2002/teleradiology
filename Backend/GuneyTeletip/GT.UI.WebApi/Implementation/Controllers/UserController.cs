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
    public class UserController : AuthenticatedBaseController
    {

        [HttpPost]
        [Route("/User/GetUserList")]
        public ServiceResult<PagingResult<UserViewModel>> GetUserList(Gridable<UserViewFilter> parms)
        {
            var cx = GetBussinesContext();
            var service = new UserDataService(cx);
            return HttpMessageService.Ok(service.GetUserList(parms));
        }

        [HttpPost]
        [Route("/User/Save")]
        public ServiceResult<int> Save(UserView model)
        {
            var cx = GetBussinesContext();
            var service = new UserDataService(cx);
            return HttpMessageService.Ok(service.Save(model));
        }

        [HttpPost]
        [Route("/User/GetByID")]
        public ServiceResult<UserViewModel> GetByID(UserUIModel model)
        {
            var cx = GetBussinesContext();
            var service = new UserDataService(cx);
            return HttpMessageService.Ok(service.GetByID(model.UserID));
        }

        [HttpPost]
        [Route("/User/Delete")]
        public ServiceResult<int> Delete(UserUIModel model)
        {
            var cx = GetBussinesContext();
            var service = new UserDataService(cx);
            return HttpMessageService.Ok(service.Delete(model.UserID));
        }

        [HttpPost]
        [Route("/User/GetRolList")]
        public ServiceResult<List<RoleViewModel>> GetRolList()
        {
            var cx = GetBussinesContext();
            var service = new UserDataService(cx);
            return HttpMessageService.Ok(service.GetRolList());
        }

        [HttpPost]
        [Route("/User/GetRoleByID")]
        public ServiceResult<long> GetRoleByID(UserUIModel model)
        {
            var cx = GetBussinesContext();
            var service = new UserDataService(cx);
            return HttpMessageService.Ok(service.GetRoleByID(model.UserID));
        }

        [HttpPost]
        [Route("/User/SaveRol")]
        public ServiceResult<int> SaveRol(SaveRolUIModel model)
        {
            var cx = GetBussinesContext();
            var service = new UserDataService(cx);
            return HttpMessageService.Ok(service.SaveRol(model.UserID, model.RolID));
        }

        [HttpPost]
        [Route("/User/GetTenantList")]
        public ServiceResult<List<TenantViewModel>> GetTenantList()
        {
            var cx = GetBussinesContext();
            var service = new UserDataService(cx);
            return HttpMessageService.Ok(service.GetTenantList());
        }

        [HttpPost]
        [Route("/User/SaveTenant")]
        public ServiceResult<int> SaveTenant(SaveTenantUIModel model)
        {
            var cx = GetBussinesContext();
            var service = new UserDataService(cx);
            return HttpMessageService.Ok(service.SaveTenant(model.UserID, model.TenantIDList));
        }

        [HttpPost]
        [Route("/User/GetTenantListByUserID")]
        public ServiceResult<List<TenantViewModel>> GetTenantListByUserID(UserUIModel model)
        {
            var cx = GetBussinesContext();
            var service = new UserDataService(cx);
            return HttpMessageService.Ok(service.GetTenantListByUserID(model.UserID));
        }
    }
}
