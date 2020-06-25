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

            };


            int TakeTop = AppSettings.GetCurrent().InfinityOracleTakeTopSettings.InfinityOracleTakeTop;



            var list1 = _InfOracleCompositeRepository.Query(f)
               .OrderBy(o=>o.StudyKey).Skip(0).Take(TakeTop).ToList();


           //var studyKeyList= list1.Select(o => o.StudyKey);
           //foreach (var study in list1)
           //{
           // //    var series=_Workspace.Query<Series>().Where(o => o.StudyKey == study.StudyKey).ToList();
           // //    if(series.Count>0)
           // //    {

           // //    }
           // //    var serie1 = study.Series.FirstOrDefault();
           // }



            return list1;


           
        }

        //public List<InfOracleViewModel> GetInfOracleList(InfOracleFilter filter)
        //{
        //    var f = new InfStudyConditionFilter
        //    {
        //        AccessionNo = filter.Accession_no,
        //        InfStudyPkLast = filter.Infstudypklast,
        //        CreationStartDate = filter.Infcreationstartdate,

        //    };
        //    return _InfOracleCompositRepository.Query(f);
        //}


    }
}
