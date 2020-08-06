using GT.Core.Settings.Global.Model;
using GT.DataService.Implementation;
using GT.UI.WebApi.Controllers;
using GT.UI.WebApi.Models.Data.FileOperation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace GT.UI.WebApi.Implementation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileOperationController: AuthenticatedBaseController
    {
        [HttpGet]
        [Route("/FileOperation/Download")]
        public IActionResult Download(FileOpreationModel model)
        {
            var cx = GetBussinesContext();
            var service = new StudyKosDataService(cx);
             var fileName = service.GetFileNameByID(model.FileID);
            var filePath = FilePathSettings.GetFilePathFromFileName(model.FileID.ToString()+".xlsx");
            var contentType = "APPLICATION/octet-stream";
            return PhysicalFile(filePath, contentType, fileName);
        }
    }
}
