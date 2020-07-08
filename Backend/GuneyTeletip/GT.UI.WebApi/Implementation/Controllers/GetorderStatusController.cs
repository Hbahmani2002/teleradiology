using GT.DataService.Implementation;
using GT.DataService.Model;
using GT.Repository.Models.View;
using GT.UI.WebApi.Controllers;
using GT.UI.WebApi.Models;
using GT.UTILS.GRID;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GT.UI.WebApi.Implementation.Controllers
{
    [ApiController]

    [Route("[controller]")]
    public class GetorderStatusController : AuthenticatedBaseController
    {
        [HttpPost]
        [Route("/GetorderStatus/GetJobList")]
        public ServiceResult<PagingResult<GetorderStatusViewModel>> GetGetorderStatusList(Gridable<GetorderStatusViewFilter> parms)
        {
            var cx = GetBussinesContext();
            var service = new GetorderStatusDataService(cx);
            return HttpMessageService.Ok(service.GetGetorderStatusList(parms));
        }

        [HttpPost]
        [Route("/GetorderStatus/GetTeletipStatusList")]
        public ServiceResult<List<TeletipStatusViewModel>> GetTeletipStatusList()
        {
            var cx = GetBussinesContext();
            var service = new GetorderStatusDataService(cx);
            return HttpMessageService.Ok(service.GetTeletipStatusList());
        }
    }
}
