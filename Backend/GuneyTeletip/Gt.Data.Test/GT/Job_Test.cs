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
    public class Job_Test
    {
        [SetUp]
        public void Setup()
        {
        }
        JobDataService service = new JobDataService(null);
        [Test]
        public void GetJobList()
        {
            var grid = new Gridable<JobViewFilter>();

            var filter = new JobViewFilter()
            {
                BasTarih = DateTime.Now.AddYears(-1),
                BitTarih = DateTime.Now,
            };
            grid.Filter = filter;
            var list = service.GetJobList(grid);
       }

        [Test]
        public void SaveException()
        {
            var list = service.SaveException(1968,"DenemeLog");
        }
    }
}
