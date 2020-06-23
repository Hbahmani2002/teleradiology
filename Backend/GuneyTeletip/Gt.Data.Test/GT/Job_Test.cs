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
        JobDataService service = new JobDataService(new BussinessContext(new UserContextModel(1)));
        [Test]
        public void GetJobList()
        {
            var grid = new Gridable<JobViewFilter>();

            var filter = new JobViewFilter();
            grid.Filter = filter;
            var list = service.GetJobList(grid);
       }
    }
}
