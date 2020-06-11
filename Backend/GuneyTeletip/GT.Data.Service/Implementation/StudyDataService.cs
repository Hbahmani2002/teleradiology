using GT.Persistance.Domain.infinity.Models;
using GT.Repository.Implementation;
using MEDLIFE.PERSISTANCE;
using MEDLIFE.SERVICE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GT.Data.Service.Implementation
{
    public class StudyDataService : BaseService
    {
        AbstractWorkspace _Workspace;
        StudyRepository studyRepository;
        public StudyDataService(IBussinessContext context) : base(context)
        {
            _Workspace = WorkspaceFactory.Create(true);
            studyRepository = new StudyRepository(_Workspace);
        }

        public List<Study> GetStudyList()
        {
            return studyRepository.Query().ToList();
        }
    }
}
