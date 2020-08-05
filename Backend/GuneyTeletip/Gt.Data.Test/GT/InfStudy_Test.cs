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
            var eslesmeDurumuList = new long[1];
            eslesmeDurumuList[0] = 20;
            filter.EslesmeDurumuList = eslesmeDurumuList;
            var list = service.GetInfStudyList(grid);
        }

        [Test]
        public void Save()
        {
            var items = new List<InfOraclePostgreStudyViewModel>();
            var item = new InfOraclePostgreStudyViewModel
            {
                PatientId= "111111111111111111111111111111111111111111111"
            };
            items.Add(item);
            service.Save(items, 0);
        }

    }
}
