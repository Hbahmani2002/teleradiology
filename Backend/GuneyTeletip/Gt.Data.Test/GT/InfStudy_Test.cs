using GT.DataService.Implementation;
using GT.DataService.Model;
using GT.Repository.Models.Filter;
using GT.SERVICE;
using GT.UTILS.GRID;
using Microsoft.VisualBasic;
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
            filter.BasTarih = new DateTime(2020,07,01);
            var list = service.GetInfStudyList(grid);
        }

        [Test]
        public void GetKosDurumIst()
        {
              var list = service.GetKosDurumIst();
        }

    }
}
