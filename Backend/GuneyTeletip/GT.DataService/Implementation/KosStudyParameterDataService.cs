using Gt.PERSISTANCE;
using GT.DataService.Model;
using GT.Persistance.Domain.Models;
using GT.Repository.Conditions;
using GT.Repository.Implementation;
using GT.Repository.Implementation.Composite;
using GT.Repository.Models.View;
using GT.Repository.Models.View.Composite;
using GT.SERVICE;
using GT.UTILS.GRID;
using System;
using System.Collections.Generic;
using System.Linq;
using GT.Core.Settings;
using GT.DataService.infinity.Implementation;
using System.Collections;
using AppAbc.Data.Service;
using static GT.Repository.Conditions.InfStudyConditionFilter;
using static GT.Repository.Conditions.StudyOperationCountCondition;
using GT.Repository.infinity.Model.View;

namespace GT.DataService.Implementation
{

  

                public class KosStudyParameterDataService : BaseService
                {



                    InfStudyRepository _InfStudyRepository;
                    TenantCompositeRepository tenatCompositeRepository;
                    InfStudyParameterRepository _InfStudyParameterRepository;
                    InfBatchRepository _InfBatchRepository;
                    InfStudyHistoryRepository infStudyHistoryRepository;
                    KosEnumTypeRepository kosEnumTypeRepository;
                    ModalityRepository modalityRepository;
                    KosDurumIstCompositeRepository kosDurumIstCompositeRepository;
                    MakeKosCompositeRepository makeKosCompositeRepository;
                    KosStudyJobRepository kosStudyJobRepository;
                    KosDeleteCompositeRepository kosDeleteCompositeRepository;
                    StudyOperationCountRepository studyOperationCount;
                    GetorderStatusRepository getorderStatusRepository;
                    KosDurumOrderCompositeRepository KosDurumOrderCompositeRepository;
                    AppFilePathRepository appFilePathRepository;
                    KosInstanceRepository _kosInstanceRepository;

                    public KosStudyParameterDataService(IBussinessContext context, bool sqlLogging = false) : this(context, GTWorkspaceFactory.Create(sqlLogging))
                    {

                    }

                    public KosStudyParameterDataService(IBussinessContext context, AbstractWorkspace Workspace) : base(context, Workspace)
                    {
                        _InfStudyRepository = new InfStudyRepository(_Workspace);
                        tenatCompositeRepository = new TenantCompositeRepository(_Workspace);
                        _InfStudyParameterRepository = new InfStudyParameterRepository(_Workspace);
                        _InfBatchRepository = new InfBatchRepository(_Workspace);
                        infStudyHistoryRepository = new InfStudyHistoryRepository(_Workspace);
                        kosEnumTypeRepository = new KosEnumTypeRepository(_Workspace);
                        modalityRepository = new ModalityRepository(_Workspace);
                        kosDurumIstCompositeRepository = new KosDurumIstCompositeRepository(_Workspace);
                        makeKosCompositeRepository = new MakeKosCompositeRepository(_Workspace);
                        kosStudyJobRepository = new KosStudyJobRepository(_Workspace);
                        kosDeleteCompositeRepository = new KosDeleteCompositeRepository(_Workspace);
                        studyOperationCount = new StudyOperationCountRepository(_Workspace);
                        getorderStatusRepository = new GetorderStatusRepository(_Workspace);
                        KosDurumOrderCompositeRepository = new KosDurumOrderCompositeRepository(_Workspace);
                        appFilePathRepository = new AppFilePathRepository(_Workspace);
                        _kosInstanceRepository = new KosInstanceRepository(_Workspace);


                    }



                    public void Save(IEnumerable<KosStudyParameter> items)
                    {

                        foreach (KosStudyParameter item in items)
                        { 
                            var ParamterTimertenatID = _InfStudyParameterRepository.GetByTenatID(item.FkTenant.Value);

                            if (ParamterTimertenatID == null)
                            {
                                throw new Exception("User bulunamadı. tenatID:" + item.FkTenant.Value);

                            }
                            else
                            {


                                DateTime D1 = new DateTime(ParamterTimertenatID.TimeStart.Value.Year, ParamterTimertenatID.TimeStart.Value.Month, ParamterTimertenatID.TimeStart.Value.Day);
                                DateTime D2 = new DateTime(ParamterTimertenatID.TimeStop.Value.Year, ParamterTimertenatID.TimeStop.Value.Month, ParamterTimertenatID.TimeStop.Value.Day);
                                DateTime NowDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

                                if (NowDate > D1)
                                {

                                    ParamterTimertenatID.OracleStudyKeyLast =0;
                                    ParamterTimertenatID.TimeStart = NowDate;
                                    ParamterTimertenatID.TimeStop = NowDate.AddDays (+2);
                                    _InfStudyParameterRepository.Update(ParamterTimertenatID);
                                     _Workspace.CommitChanges();
                                }


                            }
                          
                        }
                    }



                }





}
