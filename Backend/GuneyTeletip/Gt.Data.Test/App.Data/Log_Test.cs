using App.Data.Service;
using GT.DataService.Implementation;
using GT.DataService.Model;
using GT.Repository.Models.Filter;
using GT.SERVICE;
using GT.UTILS.GRID;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using static App.Data.Service.AppLogDataService;

namespace Gt.Data.Test
{
    public class Log_Test
    {
        [SetUp]
        public void Setup()
        {
        }
        AppLogDataService service = new AppLogDataService(new BussinessContext(new UserContextModel(1)));
        [Test]
        public void GetInfStudy()
        {
            var sonuc = service.Save(LogType.OtomatikMakeKos,"denemeLog");
        }
    }
}
