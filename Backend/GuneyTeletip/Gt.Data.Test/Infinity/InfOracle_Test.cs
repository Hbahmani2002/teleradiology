using GT.DataService.Implementation;
using GT.DataService.infinity.Implementation;
using GT.DataService.infinity.Model;
using GT.DataService.Model;
using GT.Repository.Models.Filter;
using MEDLIFE.SERVICE;
using MEDLIFE.UTILS.GRID;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
namespace Gt.Data.Test.Infinity
{

    public class InfOracle_Test
    {
        [SetUp]
        public void Setup()
        {
        }
        InfOracleDataService service = new InfOracleDataService(new BussinessContext(new UserContextModel(1)));
        [Test]
        public void GetInfStudy()
        {



    




         

            var filter = new InfOracleFilter();
            filter.Accession_no = "RAM";
       
            var list = service.GetInfOracleList(filter);


        }


    }



}
