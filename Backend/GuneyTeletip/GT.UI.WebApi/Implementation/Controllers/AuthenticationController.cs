using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GT.DataService.Implementation;
using GT.Repository.Models.View;
using GT.UI.WebApi.Implementation;
using GT.UI.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GT.UI.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {

        [HttpPost]
        [Route("/Authentication/Token")]
        public ServiceResult<string> Token(LoginUIModel model)
        {
            var service = new AuthenticationDataService();
            var user=service.Login(model.UserName,model.Password);
            if (user == null)
                throw new Exception("Böyle bir kullanıcı bulunamadı");
            var token = LoginJWTService.GenerateJwtToken(user.UserID, user.UserName);
            return HttpMessageService.Ok(token);
        }

        [HttpPost]
        [Authorize]
        [Route("/Authentication/GetPermission")]
        public ServiceResult<UserTokenModel> GetPermission()
        {
            //var service = new AuthenticationDataService(null);
            //return service.GetPermission();
            //return service.GetPermission();
            var identity = this.User.Identities.FirstOrDefault();
            if (identity == null)
            {
                return null;
            }
           var list= LoginJWTService.GetTokenValues(identity);
           

            return HttpMessageService.Ok(list);
        }

        // GET api/<controller>
        [Route("/Authentication/GetUser")]
        public object GetUser()
        {
            var identity = this.User.Identities.FirstOrDefault();
            return new
            {
                UserName = identity.Name,
                Extra = string.Join(",",
                identity.Claims.Select(o => $"{o.Type}:{o.Value}"))
            };
        }
    }
}
