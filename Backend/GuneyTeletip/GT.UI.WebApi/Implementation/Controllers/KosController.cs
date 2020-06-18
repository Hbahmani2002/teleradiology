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
using MEDLIFE.UTILS.GRID;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GT.UI.WebApi.Controllers
{
    [ApiController]

    [Route("[controller]")]
    public class KosController : AuthenticatedBaseController, IKosController
    {
        [HttpPost]
        [Route("/Kos/CreateKos")]
        public ServiceResult<int> CreateKos(Gridable<InfStudyFilter> parms)
        {
            return HttpMessageService.Ok(999);
        }
        [HttpPost]
        [Route("/Kos/DeleteKos")]
        public ServiceResult<int> DeleteKos(Gridable<InfStudyFilter> parms)
        {
            return HttpMessageService.Ok(999);
        }
        [HttpPost]
        [Route("/Kos/ExportExcel")]
        public ServiceResult<string> ExportExcel(Gridable<InfStudyFilter> parms)
        {
            return HttpMessageService.Ok("Export_GEN_2020.xlsx");
        }
        [HttpPost]
        [Route("/Kos/GetKosList")]
        public ServiceResult<PagingResult<InfStudyViewModel>> GetKosList(Gridable<InfStudyFilter> parms)
        {
            return HttpMessageService.Ok(new PagingResult<InfStudyViewModel>
            {
                List = new List<InfStudyViewModel>()
                {
                    new InfStudyViewModel { AccessionNumber = "AC123", Modalite = "23", Patinetıd = "123", Patinename = "Adı soyadu", Pk = "999" }
                }
            });
        }

        [HttpPost]
        [Route("/Kos/GetModalityList")]
        public ServiceResult<PagingResult<object>> GetModalityList()
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        [Route("/Kos/ReprocessKos")]
        public ServiceResult<int> ReprocessKos(Gridable<InfStudyFilter> parms)
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        [Route("/Kos/UpdateReadKos")]
        public ServiceResult<int> UpdateReadKos(Gridable<InfStudyFilter> parms)
        {
            throw new NotImplementedException();
        }
    }
}
