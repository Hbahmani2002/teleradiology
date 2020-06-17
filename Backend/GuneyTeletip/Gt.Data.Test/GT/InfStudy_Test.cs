using GT.DataService.Implementation;
using GT.DataService.Model;
using GT.Repository.Models.Filter;
using MEDLIFE.SERVICE;
using MEDLIFE.UTILS.GRID;
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
                    InfStudyDataService service = new InfStudyDataService(new BussinessContext(new UserContextModel(1)));
                [Test]
                public void GetInfStudy()
                {



                        var grid = new Gridable<InfStudyFilter>();

                        var filter = new InfStudyFilter();
                        grid.Filter = filter;
                        filter.Patinet_id = "45529049390";
                        var list = service.GetInfStudyList(grid);


                }


        }


   



}
