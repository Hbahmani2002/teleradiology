using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GT.BAL.TeletipKos;
using GT.BAL.TeletipKos.Model;
using GT.Core.Settings.Global.Model;
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
using Util.Excel;

namespace GT.UI.WebApi.Controllers
{
    [ApiController]

    [Route("[controller]")]
    public class KosStudyController : AuthenticatedBaseController
    {
        [HttpPost]
        [Route("/Kos/CreateKos")]
        public ServiceResult<MultipleOperationResultModel> CreateKos(Gridable<KosStudyFilter> parms)
        {
            if (parms.Filter.BasTarih.HasValue)
                parms.Filter.BasTarih = parms.Filter.BasTarih.Value.AddHours(3);
            if (parms.Filter.BitTarih.HasValue)
                parms.Filter.BitTarih = parms.Filter.BitTarih.Value.AddDays(1).AddHours(2).AddMinutes(59).AddSeconds(59);
            var sd = new StudyKosService(GetBussinesContext());
            var job = sd.CreateKosJson(parms);
            return HttpMessageService.Ok(job);
        }


        [HttpPost]
        [Route("/Kos/SendKos")]
        public ServiceResult<MultipleOperationResultModel> SendKos(Gridable<KosStudyFilter> parms)
        {
            if (parms.Filter.BasTarih.HasValue)
                parms.Filter.BasTarih = parms.Filter.BasTarih.Value.AddHours(3);
            if (parms.Filter.BitTarih.HasValue)
                parms.Filter.BitTarih = parms.Filter.BitTarih.Value.AddDays(1).AddHours(2).AddMinutes(59).AddSeconds(59);
            var sd = new StudyKosService(GetBussinesContext());
            var job = sd.SendKos(parms);
            return HttpMessageService.Ok(job);
        }


        [HttpPost]
        [Route("/Kos/SendKos1")]
        public ServiceResult<int> SendKos1(Gridable<KosStudyFilter> parms)
        {
            return HttpMessageService.Ok(9901);
        }


        [HttpPost]
        [Route("/Kos/CreateKosBackground")]
        public ServiceResult<long> CreateKosBackground(KosStudyFilter parms)
        {
            if (parms.BasTarih.HasValue)
                parms.BasTarih = parms.BasTarih.Value.AddHours(3);
            if (parms.BitTarih.HasValue)
                parms.BitTarih = parms.BitTarih.Value.AddDays(1).AddHours(2).AddMinutes(59).AddSeconds(59);
            var sd = new StudyKosService(GetBussinesContext());
            var job = sd.CreateKosBackground(parms);
            return HttpMessageService.Ok(job.JobID);
        }



        [HttpPost]
        [Route("/Kos/SendKosBackground")]
        public ServiceResult<long> SendKosBackground(KosStudyFilter parms)
        {
            if (parms.BasTarih.HasValue)
                parms.BasTarih = parms.BasTarih.Value.AddHours(3);
            if (parms.BitTarih.HasValue)
                parms.BitTarih = parms.BitTarih.Value.AddDays(1).AddHours(2).AddMinutes(59).AddSeconds(59);
            var sd = new StudyKosService(GetBussinesContext());
            var job = sd.SendKosBackground(parms);
            return HttpMessageService.Ok(job.JobID);
        }

        //[HttpPost]
        //[Route("/Kos/DeleteKos")]
        //public ServiceResult<long> DeleteKos(Gridable<KosStudyFilter> parms)
        //{
        //    return HttpMessageService.Ok(999L);
        //}



        [HttpPost]
        [Route("/Kos/DeleteKos")]
        public ServiceResult<MultipleOperationResultModel> DeleteKos(Gridable<KosStudyFilter> parms)
        {
            if (parms.Filter.BasTarih.HasValue)
                parms.Filter.BasTarih = parms.Filter.BasTarih.Value.AddHours(3);
            if (parms.Filter.BitTarih.HasValue)
                parms.Filter.BitTarih = parms.Filter.BitTarih.Value.AddDays(1).AddHours(2).AddMinutes(59).AddSeconds(59);
            var sd = new StudyKosService(GetBussinesContext());
            var job = sd.DeleteKos(parms);
            return HttpMessageService.Ok(job);

        }


        [HttpPost]
        [Route("/Kos/DeleteKosBackground")]
        public ServiceResult<long> DeleteKosBackground(KosStudyFilter parms)
        {
            if (parms.BasTarih.HasValue)
                parms.BasTarih = parms.BasTarih.Value.AddHours(3);
            if (parms.BitTarih.HasValue)
                parms.BitTarih = parms.BitTarih.Value.AddDays(1).AddHours(2).AddMinutes(59).AddSeconds(59);
            var sd = new StudyKosService(GetBussinesContext());
            var job = sd.DeleteKosBackground(parms);
            return HttpMessageService.Ok(job.JobID);
        }



        [HttpPost]
        [Route("/Kos/StmGetOrderStatusForAccessionNumberlistBackground")]
        public ServiceResult<long> OrderStatusForAccessionnumberList(KosStudyFilter parms)
        {
            if (parms.BasTarih.HasValue)
                parms.BasTarih = parms.BasTarih.Value.AddHours(3);
            if (parms.BitTarih.HasValue)
                parms.BitTarih = parms.BitTarih.Value.AddDays(1).AddHours(2).AddMinutes(59).AddSeconds(59);
            var sd = new StudyKosService(GetBussinesContext());
            var job = sd.StmGetOrderStatusForAccessionNumberlistBackground(parms);
            return HttpMessageService.Ok(job.JobID);
        }



        [HttpPost]
        [Route("/Kos/ExportExcel")]
        public ServiceResult<long> ExportExcel(Gridable<KosStudyFilter> parms)
        {
            if (parms.Filter.BasTarih.HasValue)
                parms.Filter.BasTarih = parms.Filter.BasTarih.Value.AddHours(3);
            if (parms.Filter.BitTarih.HasValue)
                parms.Filter.BitTarih = parms.Filter.BitTarih.Value.AddDays(1).AddHours(2).AddMinutes(59).AddSeconds(59);
            var cx = GetBussinesContext();
            var service = new StudyKosDataService(cx);
            var list = service.ExcelExport(parms);
            var fileName = "ExcelExport.xlsx";
            var fileIDName = FilePathSettings.GetFileIDName(fileName);
            var fileNameID = service.GetFilePathID(fileIDName);
            var fileNamePath = FilePathSettings.GetFilePathFromFileName(fileNameID.ToString() + ".xlsx");
            ExcelFile.Write(list, fileNamePath);
            return HttpMessageService.Ok(fileNameID);
        }

        [HttpPost]
        [Route("/Kos/GetKosList")]
        public ServiceResult<PagingResult<InfStudyViewModel>> GetKosList(Gridable<KosStudyFilter> parms)
        {
            if (parms.Filter.BasTarih.HasValue)
                parms.Filter.BasTarih = parms.Filter.BasTarih.Value.AddHours(3);
            if (parms.Filter.BitTarih.HasValue)
                parms.Filter.BitTarih = parms.Filter.BitTarih.Value.AddDays(1).AddHours(2).AddMinutes(59).AddSeconds(59);
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
        public ServiceResult<long> ReprocessKos(Gridable<KosStudyFilter> parms)
        {
            return HttpMessageService.Ok(999L);
        }
        [HttpPost]
        [Route("/Kos/ReprocessKosBackground")]
        public ServiceResult<long> ReprocessKosBackground(Gridable<KosStudyFilter> parms)
        {
            if (parms.Filter.BasTarih.HasValue)
                parms.Filter.BasTarih = parms.Filter.BasTarih.Value.AddHours(3);
            if (parms.Filter.BitTarih.HasValue)
                parms.Filter.BitTarih = parms.Filter.BitTarih.Value.AddDays(1).AddHours(2).AddMinutes(59).AddSeconds(59);
            var cx = GetBussinesContext();
            var service = new StudyKosService(cx);
            var job = service.ReprocessKosBackground(parms.Filter);
            return HttpMessageService.Ok(job.JobID);
        }


        //[HttpPost]
        //[Route("/Kos/UpdateReadKos")]
        //public ServiceResult<int> UpdateReadKos(Gridable<KosStudyFilter> parms)
        //public ServiceResult<MultipleOperationResultModel> UpdateReadKos(Gridable<KosStudyFilter> parms)
        //{


        //    var sd = new StudyKosService(GetBussinesContext());
        //    var job = sd.UpdateReadKos(parms);
        //    return HttpMessageService.Ok(job.JobID);


        //    //var sd = new StudyKosService(GetBussinesContext());
        //    //var job = sd.UpdateReadKos(parms);
        //    //return HttpMessageService.Ok(job);

        //}

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
