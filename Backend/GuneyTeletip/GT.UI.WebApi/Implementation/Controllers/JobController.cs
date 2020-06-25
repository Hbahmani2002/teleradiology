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
using GT.UI.WebApi.Models.Data.Kos;
using GT.UI.WebApi.Models.KosModel;
using GT.UI.WebApi.Models.UserModel;
using GT.UTILS.GRID;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Util.Extensions;

namespace GT.UI.WebApi.Controllers
{
    [ApiController]

    [Route("[controller]")]
    public class JobController : AuthenticatedBaseController
    {
        [HttpPost]
        [Route("/Job/GetJobList")]
        public ServiceResult<PagingResult<JobViewModel>> GetJobList(Gridable<JobViewFilter> parms)
        {
            var cx = GetBussinesContext();
            var service = new JobDataService(cx);
            return HttpMessageService.Ok(service.GetJobList(parms));
        }

    }
}
