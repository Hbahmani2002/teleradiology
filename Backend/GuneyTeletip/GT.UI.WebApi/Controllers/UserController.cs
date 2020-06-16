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
using MEDLIFE.UTILS.GRID;
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
        public ServiceResult<int> GetPermission(UserView model)
        {
            var service = new UserDataService(null);
            return HttpMessageService.Ok(service.Save(model));
        }
    }
}
