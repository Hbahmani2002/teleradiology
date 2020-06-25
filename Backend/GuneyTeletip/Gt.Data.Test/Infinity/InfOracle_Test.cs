using GT.DataService.Implementation;
using GT.DataService.infinity.Implementation;
using GT.DataService.infinity.Model;
using GT.DataService.Model;
using GT.PERSISTANCE.DOMAIN.Models;
using GT.Repository.Models.Filter;
using GT.SERVICE;
using GT.UTILS.GRID;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
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
            filter.Infcreationstartdate = new DateTime(2019, 01, 01);
            filter.Infstudypklast = 995;
            filter.Accession_no = "K";
            var list = service.GetInfOracleList(filter);


        }

        [Test]
        public void TestOracleSqlRaw()
        {
            var db = new InfDataContext();
            string RAPOR_SQL = "";
            RAPOR_SQL = "";
            
            
            RAPOR_SQL += @"   
SELECT * FROM  ( 
SELECT t.STUDY_KEY , t.PATIENT_ID FROM TEST_USER.STUDY t WHERE 1=1 AND  t.PATIENT_ID='10010004028' ;
) WHERE ROWNUM <= 2 
";

         

            var res=db.TestSql.FromSqlRaw(RAPOR_SQL).ToList();


                



        }
    }
}
