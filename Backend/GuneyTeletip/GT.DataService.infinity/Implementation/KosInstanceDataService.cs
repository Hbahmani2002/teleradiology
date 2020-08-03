using Gt.PERSISTANCE;
using GT.DataService.infinity.Conditions;
using GT.DataService.infinity.Model;
using GT.Persistance.Domain.Models;
using GT.PERSISTANCE;
using GT.Repository.infinity.Conditions;
using GT.Repository.infinity.Implementation.CompositeView;
using GT.Repository.infinity.Model.View;
using GT.SERVICE;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace GT.DataService.infinity.Implementation
{
    public class KosInstanceDataService : BaseService
    {
        AbstractWorkspace _Workspace;
        KosInstanceCompositeRepository kosInstanceCompositeRepository;
        public KosInstanceDataService(IBussinessContext context) : base(context)
        {
            _Workspace = InfWorkspaceFactory.Create(true);
            kosInstanceCompositeRepository = new KosInstanceCompositeRepository(_Workspace);
        }




        public void Save(IEnumerable<KosInstanceViewModel> items, int otomatik)
        {



            try
            {
               



                var list = new List<KosInstanceViewModel>();
                foreach (KosInstanceViewModel item in items)
                {



          
                    var KosInstance = new KosInstance();

                    if (item.StudyKey == null)
                    {




                        KosInstance.PatientId = item.PatientID;
                        KosInstance.PatinetName = item.PatientName;
                        KosInstance.OracleStudyKey = Convert.ToInt32( item.StudyKey );
                        KosInstance.StudyInstanceuid = item.StudyInstanceUID;
                        KosInstance.SeriInstanceuid = item.SeriesInstanceUID;
                        KosInstance.SopInstanceuid = item.SopInstanceUID;
                        KosInstance.Modality = item.Modalities;
                        KosInstance.AccessionNo = item.AccessNo;
                        KosInstance.SeriInfo = item.SeriesInfo;
     
                        KosInstance.VolumePath = item.VolumePathName;
                        KosInstance.InstitutionFilename = item.FileName;
                        KosInstance.InstitutionPathname = "";
                        KosInstance.UserFk = 1;
                        KosInstance.UserFkLastModfiead = 1;
                        KosInstance.TimeCreated = DateTime.Now;
                        KosInstance.TimeDelete = DateTime.Now;
              
                        _InfStudyRepository.Add(KosInstance);

          
                        _Workspace.CommitChanges();




                    }
                    else
                    {



                    }



                }
            }
            catch (Exception ex)
            {


   
                throw new Exception("InfOrc Save. Hata-1004:" + " " + ex.Message.ToString());
            }

        }




        public List<KosInstanceViewModel> KosInstanceOracleList(KosInstanceViewFilter filter)
        {
            var f = new InfStudyConditionFilter { PatientID=filter.PatientID};
            var s = new SeriesConditionFilter { StudyKey = filter.StudyKey };
            var gelenList = kosInstanceCompositeRepository.Query(f,s).ToList();
            //var list = gelenList
            //      .Where(o => (o.SeriesInfo == filter.SeriesInfo) && (o.PatientID==filter.PatientID))
            //      .OrderBy(o => o.StudyKey)
            //      .Skip(0)
            //      .Take(500)
            //      .ToList();
            return gelenList;
        }
    }
}
