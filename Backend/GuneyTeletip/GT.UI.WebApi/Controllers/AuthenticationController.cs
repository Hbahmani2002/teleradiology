using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GT.DataService.Implementation;
using GT.Repository.Models.View;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GT.UI.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        [HttpGet]
        [Route("/Authentication/Token")]
        public ServiceResult<UserLoginViewModel> Token()
        {
            var service = new AuthenticationDataService(null);
            return service.Login();
        }

        [HttpGet]
        [Route("/Authentication/GetPermission")]
        public ServiceResult<PermissionViewModel> GetPermission()
        {
            var service = new AuthenticationDataService(null);
            return service.GetPermission();
        }
    }
}
