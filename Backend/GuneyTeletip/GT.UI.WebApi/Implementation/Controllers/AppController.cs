using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    public class AppController : ControllerBase
    {
        [HttpPost]
        [Route("/App/GetVersion")]
        public ServiceResult<object> GetVersion()
        {

            var ass = Assembly.GetExecutingAssembly().GetName();
            return HttpMessageService.Ok((object)new
            {
                Version = ass.Version
            });
        }

        [HttpPost]
        [Route("/App/Control")]
        public ServiceResult<object> Control()
        {

            var ass = Assembly.GetExecutingAssembly().GetName();
            return HttpMessageService.Ok((object)new
            {
                Version = ass.Version,
                CurrentDirectory = Environment.CurrentDirectory,
                MachineName = Environment.MachineName,
                WorkingSet = Environment.WorkingSet,
            });
        }
    }
}
