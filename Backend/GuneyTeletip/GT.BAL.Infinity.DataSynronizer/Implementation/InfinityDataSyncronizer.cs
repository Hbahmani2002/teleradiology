
using GT.DataService.Implementation;
using GT.DataService.infinity.Implementation;
using GT.Persistance.Domain.Models;
using GT.Repository.Models.View;
using System;
using System.Collections.Generic;

namespace GT.BAL.Infinity.DataSynronizer
{
    public class InfinityDataSyncronizer
    {
        InfOracleDataService _InfOracleDataService;
        InfStudyDataService _InfStudyDataService;
        public InfinityDataSyncronizer()
        {            
            _InfOracleDataService = new InfOracleDataService(null);
            _InfStudyDataService = new InfStudyDataService(null);

        }
        public void SyncronizeInfinityStudyList(long tenantID, long lastID, System.DateTime? startTime, System.DateTime? endTime)
        {
            var filter = new DataService.infinity.Model.InfOracleFilter();
            filter.Infcreationstartdate = startTime;
            filter.Infstudypklast = lastID;
            var items=_InfOracleDataService.GetInfOracleList(filter);
            var list = new List<InfOraclePostgreStudyViewModel>();
            foreach (var item in items)
            {
                
                var model = new InfOraclePostgreStudyViewModel();
                model.AccessionNo = item.AccessNo;
                model.TimeCreated = item.CreationDttm;
                list.Add(model);
                throw new NotImplementedException();
                
            }
            _InfStudyDataService.Save(list);
        }
    }
}
