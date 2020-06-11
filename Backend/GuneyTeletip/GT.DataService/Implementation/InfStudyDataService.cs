using GT.Persistance.Domain.Models;
using GT.Repository.Implementation;
using MEDLIFE.PERSISTANCE;
using MEDLIFE.SERVICE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GT.DataService.Implementation
{
    public class InfStudyDataService : BaseService
    {
        AbstractWorkspace _Workspace;
        InfStudyRepository infStudyRepository;
        public InfStudyDataService(IBussinessContext context) : base(context)
        {
            _Workspace = WorkspaceFactory.Create(true);
            infStudyRepository = new InfStudyRepository(_Workspace);
        }

        public List<InfStudy> GetInfStudyList()
        {
            return infStudyRepository.Query(o => o.AccessionNo=="100").ToList();
        }
    }
}
