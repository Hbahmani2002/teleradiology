using GT.BAL.Job.Interface;
using GT.DataService.Implementation;
using GT.Persistance.Domain.Models;
using GT.Repository.Models.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT.BAL.Job.Implementation
{

    internal class InfJobDataService : IInfJobDataService
    {
        InfStudyDataService _InfStudyDataService;
        //GTParamterDataService _GTParamterDataService;
        public InfJobDataService()
        {
            _InfStudyDataService = new InfStudyDataService(null);
            //_InfStudyDataService = new InfStudyDataService(null);
        }
        public IEnumerable<IInfJobServiceDefinition> GetInfinityJobParameterList()
        {
            throw new NotImplementedException();
        }


        public IEnumerable<InfStudyViewModel> GetInfinityStudyList(long tenantID, long lastID, DateTime startTime)
        {
            throw new NotImplementedException();
        }
    }
}
