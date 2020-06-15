using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GT.DataService.Implementation;
using GT.Repository.Models.View;
using GT.UI.WebApi.Implementation;
using GT.UI.WebApi.Models;
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
        public ServiceResult<string> Token(LoginUIModel model)
        {
            //var service = new AuthenticationDataService(null);
            //return service.Login();
            var token = LoginJWTService.generateJwtToken(10, model.UserName);
            return HttpMessageService.ServiceResult(token);
        }

        [HttpGet]
        [Route("/Authentication/GetPermission")]
        public ServiceResult<List<ClaimsIdentity>> GetPermission()
        {
            //var service = new AuthenticationDataService(null);
            //return service.GetPermission();

            var list = this.User.Identities.ToList();
            return HttpMessageService.ServiceResult(list);
        }
    }
}
