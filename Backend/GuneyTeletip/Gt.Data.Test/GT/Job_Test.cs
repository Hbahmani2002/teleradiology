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
        
        [Test]
        public void GetJobList()
        {
            JobDataService service = new JobDataService(null);
            var grid = new Gridable<JobViewFilter>();

            var filter = new JobViewFilter()
            {
                BasTarih = DateTime.Now.AddYears(-1),
                BitTarih = DateTime.Now,
            };
            grid.Filter = filter;
            var list = service.GetJobList(grid);
       }
    }
}
