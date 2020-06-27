using GT.BAL.TeletipKos;
using GT.Core.Settings;
using GT.DataService.infinity.Implementation;
using GT.DataService.infinity.Model;
using GT.Job.Implementation;
using GT.Job.Model.AutoJobs;
using GT.SERVICE;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Util.Logger;
using System.Text;
using GT.UI.WebApi.Models;

namespace GT.BAL.Test
{

    public class UC9
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void UC8_8()
        {

            var gelen_app_setting = File.ReadAllText("appsettings.json");

            var y = JsonConvert.DeserializeObject<string>(gelen_app_setting);




        }

        public class TypeJson
        {
            public string patientId { get; set; }
            public string KOS { get; set; }
            public string RepositoryUr { get; set; }
            public string Result { get; set; }

            public TypeJson()
            {
            }


        }
    }
}
