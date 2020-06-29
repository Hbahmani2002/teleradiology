using GT.DataService.Implementation;
using GT.DataService.Model;
using GT.Repository.Models.Filter;
using GT.SERVICE;
using GT.UTILS.GRID;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gt.Data.Test
{
    public class InfStudy_Test
    {
        [SetUp]
        public void Setup()
        {
        }
        StudyKosDataService service = new StudyKosDataService(new BussinessContext(new UserContextModel(1)));
        [Test]
        public void GetInfStudy()
        {
            var grid = new Gridable<KosStudyFilter>();

            var filter = new KosStudyFilter();
            grid.Filter = filter;
            var tcList = new string[2];
            tcList[0] = "61840519756";
            tcList[1] = "44528074396";
            filter.TCList = tcList;
            var list = service.GetInfStudyList(grid);
        }

        [Test]
        public void GetKosDurumIst()
        {
              var list = service.GetKosDurumIst();
        }

    }
}
