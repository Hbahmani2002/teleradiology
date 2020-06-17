using GT.DataService.Model;
using GT.Repository.Conditions;
using GT.Repository.Implementation;
using GT.Repository.Models.View;
using MEDLIFE.PERSISTANCE;
using MEDLIFE.SERVICE;
using MEDLIFE.UTILS.GRID;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT.DataService.Implementation
{


    public class InfStudyDataService : BaseService
    {
        AbstractWorkspace _Workspace;
        InfStudyRepository _InfStudyRepository;



        public InfStudyDataService(IBussinessContext context) : base(context)
        {
            _Workspace = WorkspaceFactory.Create(true);

            _InfStudyRepository = new InfStudyRepository(_Workspace);


        }


        public PagingResult<InfStudyViewModel> GetInfStudyList(Gridable<InfStudyFilter> parms)
        {
            if (parms == null)
            {
                parms = new Gridable<InfStudyFilter>();
            }
            if (parms.Filter == null)
            {
                parms.Filter = new InfStudyFilter();
            }

            var s = new InfStudyConditionFilter { 
            
                Accession_no = parms.Filter.Accession_no,
                Modality = parms.Filter.Modality,
                Patinet_id = parms.Filter.Patinet_id,
                Patine_name = parms.Filter.Patine_name,
                Pk = parms.Filter.Pk,



            };


            return _InfStudyRepository.QueryGrid(s)
                .GetGridQuery(parms);

        }

    }
}