using GT.DataService.Implementation;
using MEDLIFE.SERVICE;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT.Test.GT
{
    public class InfStudy_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        InfStudyDataService service= new InfStudyDataService(new BussinessContext(new UserContextModel(1, null)));

        [Test]
        public void Test1()
        {
            var sonuc = service.GetInfStudyList();
        }
    }
}
