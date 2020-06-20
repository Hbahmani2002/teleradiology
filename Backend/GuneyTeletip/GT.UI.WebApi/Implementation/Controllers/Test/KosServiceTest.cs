using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GT.Core.Settings;
using GT.DataService.Implementation;
using GT.DataService.Model;
using GT.Repository.Models.Filter;
using GT.Repository.Models.View;
using GT.TeletipKos;
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
using Util.Logger;
using Util.ProcessUtil;

namespace GT.UI.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KosServiceTestController : ControllerBase
    {
        [Route("/KosServiceTest/MakeKos")]
        public ServiceResult<object> KosTest()
        {
            var settings = AppSettings.GetCurrent();
            var id = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 6);
            var jobID = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "_" + id;
            var filePath = Path.Combine(settings.Log.DIR_JobsLog, $"{jobID}.txt");
            var manager = GetKosManager(filePath);


            var inputDirPath = "/dicom/study/YKCK01/20200519/E0071610";
            var outputKosFilePath = $"/dicom/kos/kos_{Guid.NewGuid().ToString().Replace("-", "")}.dcm";
            manager.MakeKos(new[]
            {
                    new MakeKosParameter("","","","","","","",inputDirPath,outputKosFilePath)
                }
            );

            return HttpMessageService.Ok((object)new
            {
                JobID = jobID,
                JobLogFilePath = filePath
            });

        }

        private static MultiKosOperationManager GetKosManager(string logFilePath)
        {
            var settings = AppSettings.GetCurrent();
            var makeKosSettings = settings.Kos.Make;
            var sendKosSettings = settings.Kos.Send;


            var logger = new TextFileLogger(logFilePath);
            var kSettings = new TeletipKosServiceSettings(
                new TeletipKosServiceSettings.MakeKosServiceSettings(makeKosSettings.AppFilePath, makeKosSettings.LocationUID, makeKosSettings.Title, makeKosSettings.TempDirectoryPath, makeKosSettings.DCM4CheeDirectoryPath),
                new TeletipKosServiceSettings.SendKosServiceSettings(sendKosSettings.AppFilePath, sendKosSettings.ServiceAddressURL)
            );
            var manager = new MultiKosOperationManager(logger, kSettings);
            return manager;
        }

        [Route("/KosServiceTest/MakeKosSingle")]
        public ServiceResult<object> MakeKosSingle()
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
    }
}
