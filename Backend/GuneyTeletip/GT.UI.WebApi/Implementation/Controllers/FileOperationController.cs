﻿using GT.Core.Settings.Global.Model;
using GT.DataService.Implementation;
using GT.UI.WebApi.Controllers;
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
        public IActionResult Download(long fileID)
        {
            var cx = GetBussinesContext();
            var service = new StudyKosDataService(cx);
             var fileName = service.GetFileNameByID(fileID);
            var filePath = FilePathSettings.GetFilePathFromFileName(fileID.ToString()+".xlsx");
            var contentType = "APPLICATION/octet-stream";
            return PhysicalFile(filePath, contentType, fileName);
        }
    }
}