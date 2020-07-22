using GT.Core.Settings.Global.Model;
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
        public HttpResponseMessage Download(Model model)
        {
            var cx = GetBussinesContext();
            var service = new StudyKosDataService(cx);
            // var fileName = service.GetFileNameByID(model.fileID);
            var fileName ="";
            var filePath = FilePathSettings.GetFilePathFromFileName(fileName);
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            //response.Content = new StringContent(ftpPath + "-" + outputPath+"-");
            //return response;
           // string mimeType = MimeMapping.GetMimeMapping(fileName);
            response.Content = new StreamContent(new FileStream(filePath, FileMode.Open, FileAccess.Read));
            //Attachment
            //response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            //NewTab
            response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue(System.Net.Mime.DispositionTypeNames.Inline);
            response.Content.Headers.ContentDisposition.FileName = fileName;
            //response.Content.Headers.ContentType = new MediaTypeHeaderValue(mimeType);
            return response;
        }
    }

    public class Model
    {
        public long fileID { get; set; }
    }
}
