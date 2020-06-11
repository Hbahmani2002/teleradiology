using GT.Persistance.Domain.infinity.Models;
using GT.Repository.Implementation;
using GT.Repository.infinity.Conditions;
using GT.Repository.infinity.Model.Filter;
using GT.Repository.infinity.Model.View;
using MEDLIFE.PERSISTANCE;
using MEDLIFE.SERVICE;
using MEDLIFE.UTILS.GRID;
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

        public PagingResult<StudyViewModel> GetStudyList(Gridable<StudyViewFilter> parms)
        {
            if (parms == null)
            {
                parms = new Gridable<StudyViewFilter>();
            }
            if (parms.Filter == null)
            {
                parms.Filter = new StudyViewFilter();
            }
            var s = new StudyConditionFilter { 
                AccessNo=parms.Filter.AccessNo,
                InstanceCount=parms.Filter.InstanceCount,
                Modalities=parms.Filter.Modalities,
                PatientID=parms.Filter.PatientID,
                PatientName=parms.Filter.PatientName,
                PatientSex=parms.Filter.PatientSex,
                StudyInstanceUID=parms.Filter.StudyInstanceUID
            };
            return studyRepository.Query(s).GetGridQuery(parms);
        }
    }
}
