using Gt.PERSISTANCE;
using GT.Core.Settings;
using GT.DataService.infinity.Conditions;
using GT.DataService.infinity.Model;
using GT.Persistance.Domain.infinity.Models;
using GT.PERSISTANCE;
using GT.Repository.infinity.Implementation.CompositeView;
using GT.Repository.infinity.Model.View;
using GT.SERVICE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace GT.DataService.infinity.Implementation
{


    public class InfOracleDataService : BaseService
    {
        AbstractWorkspace _Workspace;
        InfOracleStudyRepository _InfOracleStudyRepository;
        InfOracleCompositeRepository _InfOracleCompositeRepository;


        public InfOracleDataService(IBussinessContext context) : base(context)
        {
            _Workspace = InfWorkspaceFactory.Create(true);

            _InfOracleStudyRepository = new InfOracleStudyRepository(_Workspace);
            _InfOracleCompositeRepository = new InfOracleCompositeRepository(_Workspace);
            //_InfOracleSeriesRepository = new InfOracleSeriesRepository(_Workspace);
            //_InfOracleSeriesRepository = new InfOracleInstanceRepository(_Workspace);


        }


        public List<InfOracleViewModel> GetInfOracleList(InfOracleFilter filter)
        {
            var f = new InfStudyConditionFilter
            {
              
                AccessionNo = filter.Accession_no,
                InfStudyPkLast = filter.Infstudypklast,
                CreationStartDate = filter.Infcreationstartdate,
                CreationEndDate =filter.Infcreationenddate,
                Source_Aetitle = "DICOM CREATOR"
            };

            var s = new InfSerieConditionFilter
            {
                SeriesInfo = "DCMCREATOR"
            };





            int TakeTop = AppSettings.GetCurrent().DataServiceSettings.OracleSettings.InfinityOracleTakeTop;


            var gelenInf = _InfOracleCompositeRepository.Query(f,s);

            var gelenInfss = gelenInf.ToList();

            //var gelenList= gelenInf
            //      .Where(o=>( o.StudyDttm >= filter.Infcreationstartdate ) && (o.StudyDttm <= filter.Infcreationenddate) && (o.AccessNo.Contains(filter.Accession_no))   )
            //      .OrderBy(o => o.StudyKey )
            //      .Skip(0)
            //      .Take(20000)
            //      .ToList();



            //      var gelenList = gelenInf
            //.Where(o => (o.StudyDttm >= filter.Infcreationstartdate) && (o.StudyDttm <= filter.Infcreationenddate) && (o.AccessNo.Contains(filter.Accession_no)) && (!o.SeriesInfo.Contains(filter.SeriesInfo)) && (o.StudyKey > filter.Infstudypklast))
            //.OrderBy(o => o.StudyKey)
            //.Skip(0)
            //.Take(10000)
            //.ToList();

            // var gelenList = gelenInf
            //.Where(o => (o.AccessNo.Contains(filter.Accession_no)) && (!o.Source_Aetitle.Contains(filter.Source_Aetitle)) )
            //.OrderBy(o => o.StudyKey)
            //.Skip(0)
            //.Take(50000)
            //.ToList();



            // var gelenList = gelenInf
            //.Where(o => (o.StudyDttm >= filter.Infcreationstartdate) && (o.StudyDttm <= filter.Infcreationenddate) && (o.AccessNo.Contains(filter.Accession_no)) && (!o.Source_Aetitle.Contains(filter.Source_Aetitle)) && (o.StudyKey > filter.Infstudypklast))
            //.OrderBy(o => o.StudyKey)
            //.Skip(0)
            //.Take(50000)
            //.ToList();

            var gelenList = gelenInf
           .Where(o => (o.StudyDttm >= filter.Infcreationstartdate) && (o.StudyDttm <= filter.Infcreationenddate) && (o.AccessNo.Contains(filter.Accession_no)) && (!o.SeriesInfo.Contains(filter.SeriesInfo)) && (!o.Source_Aetitle.Contains(filter.Source_Aetitle)) && (o.StudyKey > filter.Infstudypklast))
           .OrderBy(o => o.StudyKey)
           .Skip(0)
           .Take(10000)
           .ToList();

            return gelenList;




        }




        public List<InfOracleViewModel> ManuelGetInfOracleList(InfOracleFilter filter)
        {
            var f = new InfStudyConditionFilter
            {
                AccessionNo = filter.Accession_no,      
                InfStudyPkLast = filter.Infstudypklast,
                CreationStartDate = filter.Infcreationstartdate,
                CreationEndDate = filter.Infcreationenddate,
                Acc = filter.AccessionNoListte,
                Source_Aetitle ="DICOM CREATOR" 

            };

            var s = new InfSerieConditionFilter
            {
                SeriesInfo = "DCMCREATOR"
            };


            int TakeTop = AppSettings.GetCurrent().DataServiceSettings.OracleSettings.InfinityOracleTakeTop;


            var gelenInf = _InfOracleCompositeRepository.QueryM(f,s);



            //var list = gelenInf.ToList();
            //foreach (var n in filter.AccessionNoListte)
            //{
            //    list.Add(n);
            //}
            //var listString = list;
            //.Select(o => o.ToString(""))
            //.ToList();
            //exp = exp.And(o => listString.Contains(o.AccessNo));



            var gelenList = gelenInf
                 .Where(o => (o.AccessNo == filter.Accession_no) && (!o.SeriesInfo.Contains(filter.SeriesInfo)) )
                 .OrderBy(o => o.StudyKey)
                 .Skip(0)
                 .Take(500)
                 .ToList();





            return gelenList;




        }



    }
}
