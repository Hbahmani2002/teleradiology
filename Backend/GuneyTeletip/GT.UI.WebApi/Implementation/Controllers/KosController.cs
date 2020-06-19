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
    public class KosController : AuthenticatedBaseController
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
            var list = RandomDataGenerator.CreateRandom<InfStudyViewModel>(12).ToList();
            //return HttpMessageService.Ok(new PagingResult<InfStudyViewModel>
            //{
            //    List = new List<InfStudyViewModel>()
            //    {
            //        new InfStudyViewModel {}
            //    }
            //});
            return HttpMessageService.Ok(new PagingResult<InfStudyViewModel>
            {
                List = list
            });
        }

        [HttpPost]
        [Route("/Kos/GetModalityList")]
        public ServiceResult<List<KosEnumTypeViewModel>> GetModalityList()
        {
            var cx = GetBussinesContext();
            var service = new InfStudyDataService(cx);
            return HttpMessageService.Ok(service.GetModalityList());
        }

        [HttpPost]
        [Route("/Kos/ReprocessKos")]
        public ServiceResult<int> ReprocessKos(Gridable<InfStudyFilter> parms)
        {
            return HttpMessageService.Ok(40);
        }

        [HttpPost]
        [Route("/Kos/UpdateReadKos")]
        public ServiceResult<int> UpdateReadKos(Gridable<InfStudyFilter> parms)
        {
            return HttpMessageService.Ok(66);
        }

        [HttpPost]
        [Route("/Kos/GetByID")]
        public ServiceResult<InfStudyViewModel> GetByID(KosModel model)
        {
            var cx = GetBussinesContext();
            var service = new InfStudyDataService(cx);
            return HttpMessageService.Ok(service.GetByID(model.ID));
        }

        [HttpPost]
        [Route("/Kos/GetKosHistoryByStudyID")]
        public ServiceResult<List<KosHistoryModel>> GetKosHistoryByStudyID(StudyHistoryModel model)
        {
            var cx = GetBussinesContext();
            var service = new InfStudyDataService(cx);
            return HttpMessageService.Ok(service.GetKosHistoryByStudyID(model.ID));
        }

        [HttpPost]
        [Route("/Kos/GetEnumTypeList")]
        public ServiceResult<List<KosEnumTypeViewModel>> GetEnumTypeList()
        {
            var cx = GetBussinesContext();
            var service = new InfStudyDataService(cx);
            return HttpMessageService.Ok(service.GetEnumTypeList());
        }

    }
}
