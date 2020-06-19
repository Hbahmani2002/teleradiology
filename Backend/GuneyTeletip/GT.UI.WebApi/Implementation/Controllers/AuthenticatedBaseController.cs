using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GT.DataService.Implementation;
using GT.DataService.Model;
using GT.Repository.Models.Filter;
using GT.Repository.Models.View;
using GT.SERVICE;
using GT.UI.WebApi.Implementation;
using GT.UI.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GT.UI.WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class AuthenticatedBaseController : ControllerBase
    {
        public UserTokenModel TokenModel
        {
            get
            {
                var identity = this.User.Identities.FirstOrDefault();
                if (identity == null)
                {
                    throw new ApplicationException("Yetkisiz Kullanıcı");
                }
                var item = LoginJWTService.GetTokenValues(identity);
                return item;
            }
        }

        public IBussinessContext GetBussinesContext()
        {
            var id = this.TokenModel.ID;
            var cxModel = new UserContextModel(id);
            var cx = new BussinessContext(cxModel);
            return cx;
        }

    }
}
