using Newtonsoft.Json;
using NUnit.Framework;
using System.IO;

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
