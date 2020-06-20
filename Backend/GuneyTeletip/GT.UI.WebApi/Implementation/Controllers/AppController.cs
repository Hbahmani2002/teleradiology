using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
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
using Util.ProcessUtil;

namespace GT.UI.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppController : ControllerBase
    {

        [Route("/App/Control")]
        public ServiceResult<object> Control()
        {
            var basePath = Environment.CurrentDirectory;
            var kosPath = Path.GetFullPath("../teletip_kos/", basePath);

            var ass = Assembly.GetExecutingAssembly().GetName();
            return HttpMessageService.Ok((object)new
            {
                Version = ass.Version.ToString(),
                CurrentDirectory = Environment.CurrentDirectory,
                MachineName = Environment.MachineName,
                WorkingSet = Environment.WorkingSet,
                MakeKosPath = Path.Combine(kosPath, "MakeKOS_v21.jar"),
                SendKosPath = Path.Combine(kosPath, "SendKOS_v15.jar"),
            });
        }

        [Route("/App/Settings")]
        public ServiceResult<object> Settings()
        {
            var basePath = Environment.CurrentDirectory;
            var kosPath = Path.GetFullPath("../teletip_kos/", basePath);
            var makeKosPath = Path.Combine(kosPath, "MakeKOS_v21.jar");

            var WorkingDirectory = "/dicom";
            var processParameter = GetInfo();

            Exception ex = null;
            ProcessResult res = null;
            try
            {
                //res = ProcessUtil.Start("java", processParameter, WorkingDirectory);
                res = ProcessUtil.Start("java", processParameter);
            }
            catch (Exception exp)
            {
                ex = exp;
            }


            return HttpMessageService.Ok((object)new
            {
                ProcessParameter = processParameter,
                WorkingDirectory = WorkingDirectory,
                Result = res,
                Ex = ex,
            });

        }
        public string GetInfo()
        {

            var makeKosJarName = "MakeKOS_v21";
            var makeKosAppLocation = $"/gt/app/teletip_kos/{makeKosJarName}.jar";

            var output = $"/gt/dicom/kos/test_{Guid.NewGuid().ToString().Replace("-", "")}.dcm";
            var input = "/gt/dicom/study/YKCK01/20200519/E0071610";

            var tempTLocation = "/gt/dicom/temp_kos";
            var dcmLocation = "/gt/app/teletip_kos/dcm4che-5.22.2/bin";
            var res = $@" --title DCM-113030 --location-uid  1.3.6.1.4.1.21367.2017.10.26.111 --temp-tlocation {tempTLocation} --dcm-dcmlocation {dcmLocation} -o {output} {input}";
            //java -jar /app/dicom/MakeKOS_v21.jar --title DCM-113030 --location-uid  1.3.6.1.4.1.21367.2017.10.26.111 --temp-tlocation /app/dicom/temp --dcm-dcmlocation /app/dicom/dcm4che-5.22.2/bin -o /app/dicom/output/test.dcm /app/dicom/dicom-input-files
            var processStr = $"-jar {makeKosAppLocation} {res}";
            return processStr;

        }

        public class ModelItem
        {
            public long? ID { get; set; }
            public string Name { get; set; }
            //public DateTime? Date { get; set; }
            public bool HasValue { get; set; }

        }

        [HttpPost]
        [Route("/App/ModelTest")]
        public ServiceResult<ModelItem> ModelTest(ModelItem item)
        {

            return HttpMessageService.Ok(item);

        }
    }
}
