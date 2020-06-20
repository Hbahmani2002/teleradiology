using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Claims;
using System.Threading.Tasks;
using GT.Core.Settings;
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
                Environment = new
                {
                    CurrentDirectory = Environment.CurrentDirectory,
                    MachineName = Environment.MachineName,
                    WorkingSet = Environment.WorkingSet,
                },
                Settings=AppSettings.GetCurrent()
            });
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
