using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GT.BAL.TeletipKos;
using GT.DataService.Implementation;
using GT.DataService.Model;
using GT.Repository.Models.Filter;
using GT.Repository.Models.View;
using GT.SERVICE;
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
    public class KosStudyController : AuthenticatedBaseController
    {
        [HttpPost]
        [Route("/Kos/CreateKos")]
        public ServiceResult<int> CreateKos(Gridable<InfStudyFilter> parms)
        {
            return HttpMessageService.Ok(999);
        }

        [HttpPost]
        [Route("/Kos/DeleteKosBackground")]
        public ServiceResult<long> DeleteKosBackground(InfStudyFilter parms)
        {
            var sd = new StudyKosService(GetBussinesContext());
            var job = sd.DeleteKosBackground(parms);
            return HttpMessageService.Ok(job.JobID);
        }

        [HttpPost]
        [Route("/Kos/DeleteKos")]
        public ServiceResult<long> DeleteKos(Gridable<InfStudyFilter> parms)
        {
            return HttpMessageService.Ok(999L);
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
            var cx = GetBussinesContext();
            var service = new StudyKosDataService(cx);
            return HttpMessageService.Ok(service.GetInfStudyList(parms));
        }

        [HttpPost]
        [Route("/Kos/GetModalityList")]
        public ServiceResult<List<KosEnumTypeViewModel>> GetModalityList()
        {
            var cx = GetBussinesContext();
            var service = new StudyKosDataService(cx);
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
            var service = new StudyKosDataService(cx);
            return HttpMessageService.Ok(service.GetByID(model.ID));
        }

        [HttpPost]
        [Route("/Kos/GetKosHistoryByStudyID")]
        public ServiceResult<PagingResult<KosHistoryModel>> GetKosHistoryByStudyID(Gridable<KosHistoryFilter> parms)
        {
            var cx = GetBussinesContext();
            var service = new StudyKosDataService(cx);
            return HttpMessageService.Ok(service.GetKosHistoryByStudyID(parms));
        }

        [HttpPost]
        [Route("/Kos/GetEnumTypeList")]
        public ServiceResult<List<KosEnumTypeViewModel>> GetEnumTypeList()
        {
            var cx = GetBussinesContext();
            var service = new StudyKosDataService(cx);
            return HttpMessageService.Ok(service.GetEnumTypeList());
        }

        [HttpPost]
        [Route("/Kos/GetKosDurumIst")]
        public ServiceResult<List<KosDurumIstModel>> GetKosDurumIst()
        {
            var cx = GetBussinesContext();
            var service = new StudyKosDataService(cx);
            return HttpMessageService.Ok(service.GetKosDurumIst());
        }

        [HttpPost]
        [Route("/Kos/UpdateKosDurum")]
        public ServiceResult<long> UpdateKosDurum(UpdateKosDurumModel model)
        {
            var cx = GetBussinesContext();
            throw new NotImplementedException();
        }

    }
}
