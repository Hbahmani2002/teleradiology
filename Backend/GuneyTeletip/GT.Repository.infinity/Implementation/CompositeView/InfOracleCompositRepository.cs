using Gt.PERSISTANCE;
using GT.DataService.infinity.Conditions;
using GT.Persistance.Domain.infinity.Models;
using GT.Repository.infinity.Model.View;
using GT.REPOSITORY;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GT.Repository.infinity.Implementation.CompositeView
{
    public class InfOracleCompositeRepository : AbstractRepository
    {
        public InfOracleCompositeRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }

        public IQueryable<InfOracleViewModel> Query(Expression<Func<Study, bool>> exp, Expression<Func<Series, bool>> exp1)
        {


            var infstudy = _AbstractWorkspace.Query<Study>(exp);

            var x = infstudy.ToList(); 

            //if (x > 0)
            //{
            //    //var hata = AppAbc.Data.Service.AppLogDataService.LogType.InfOrclHata;
            //    //var message = "Study ID Kayıt bulunamadı..";
            //    //_AppLogDataService.Save(hata, message + " tenantID :" + tenantID);
                

            //}



            var infseries = _AbstractWorkspace.Query<Series>(exp1);

            var infinstance = _AbstractWorkspace.Query<Instance>();
            var infinstanceLoc = _AbstractWorkspace.Query<Instanceloc>();
            var infvolume = _AbstractWorkspace.Query<Volume>();
            var infimage = _AbstractWorkspace.Query<Image>();

            var query = from stdy in infstudy

                        from seri in infseries.Where(o => o.StudyKey == stdy.StudyKey)
                                           .Take(1)
                                           .DefaultIfEmpty()
                        from ins in infinstance.Where(o => o.SeriesKey == seri.SeriesKey)
                                          .Take(1)
                                          .DefaultIfEmpty()
                        from insloc in infinstanceLoc.Where(o => o.InstanceKey == ins.InstanceKey)
                                          .Take(1)
                                          .DefaultIfEmpty()
                        from vol in infvolume.Where(o => o.VolumeCode == insloc.VolumeCode)
                                          .Take(1)
                                          .DefaultIfEmpty()

                            //let seri = infseries.Where(o => o.StudyKey == stdy.StudyKey).FirstOrDefault()
                            //let ins =  infinstance.Where(o => o.SeriesKey == seri.SeriesKey).FirstOrDefault()
                            //let insloc =  infinstanceLoc.Where(o => o.InstanceKey == ins.InstanceKey).FirstOrDefault()
                            //let vol =  infvolume.Where(o => o.VolumeCode == insloc.VolumeCode).FirstOrDefault()
                            //let img = infimage.Where(o => o.InstanceKey == insloc.InstanceKey).FirstOrDefault()
                            //join seri in infseries on stdy.StudyKey equals seri.StudyKey into t

                            //join ins in infinstance on seri.SeriesKey equals ins.SeriesKey
                            //join insloc in infinstanceLoc on ins.InstanceKey equals insloc.InstanceKey
                            //join vol in infvolume on insloc.VolumeCode equals vol.VolumeCode
                            //join img in infimage on insloc.InstanceKey equals img.InstanceKey

                        select new InfOracleViewModel
                        {
                            StudyKey = stdy.StudyKey,
                            PatientId = stdy.PatientId,
                            PatientName = stdy.PatientName,
                            PatientSex = stdy.PatientSex,
                            PatientBirthDttm = stdy.PatientBirthDttm.Value,
                            StudyInstanceUid = stdy.StudyInstanceUid,
                            StudyDttm = stdy.StudyDttm,
                            AccessNo = stdy.AccessNo,
                            Institution = stdy.Institution,
                            SeriesCount = stdy.SeriesCount,
                            InstanceCount = stdy.InstanceCount,
                            Modalities = stdy.Modalities,                            
                            Pathname = insloc.Pathname,
                            Filename = insloc.Filename,
                            VolumeCode = vol.VolumeCode,
                            VolumeType = vol.VolumeType,
                            VolumeStat = vol.VolumeStat,
                            VolumePathname = vol.Pathname,
                            ModifyDttm = stdy.ModifyDttm.Value,
                            CreationDttm = stdy.CreationDttm.Value,
                            StudyDesc = stdy.StudyDesc,
                            InfMergeKey = stdy.MergeKey,
                            SeriesInfo = seri.SeriesInfo
                            //VolumeCodeinsloc = insloc.VolumeCode 

                            

                        };

            //var g = query.ToList();

            return query;



        }


        //Durum = Convert.ToInt32( count);
        // var query2 = from seri in infseries
        // select new InfOracleStudyModel
        // {
        //     Key = seri.SeriesKey 
        // };
        // var g1 = query2
        //.Skip(0)
        //.Take(1)
        //.ToList();
        // var series = new InfManuelKeyConditionFilter
        // {
        //     Key = Convert.ToInt32(g1[0].Key),      
        // };
        // var expF = InfSeriesKeyCondition.GetInstance(series, 2);


        public IQueryable<InfOracleViewModel> QueryManuelCek(Expression<Func<Study, bool>> exp, Expression<Func<Series, bool>> exp1, InfStudyConditionFilter f)
        {
            int Durum;
            decimal KeyM;
            var s = new InfManuelKeyConditionFilter { };

          //  var expStudy = InfStudyCondition.Get(f);

          //  var infstudy = _AbstractWorkspace.Query<Study>(expStudy);
          //  var query1 = from stdy in infstudy
                      
          //  select new InfOracleViewModel
          //  {
          //      StudyKey = stdy.StudyKey ,
          //      AccessNo = stdy.AccessNo
            
          //  };


          //  var gelenInf = query1;

          //  var stdyq = gelenInf
          //       .Where(o => (o.AccessNo == f.AccessionNo))
          //       .OrderBy(o => o.StudyKey)
          //       .Skip(0)
          //       .Take(50)
          //       .ToList();



          //  if (stdyq.Count > 0)
          //  {

          //      s = new InfManuelKeyConditionFilter
          //      {

          //          Key = Convert.ToInt32(stdyq[0].StudyKey),
          //          SeriesInfo = "DCMCREATOR"


          //      };
          //  }
          //    else
          //  {
          //      s = new InfManuelKeyConditionFilter
          //      {

          //          SeriesInfo = "DCMCREATOR"


          //      };


          //  }

          //  var expM = InfSeriesKeyCondition.Get(s, 1);
          //  var infseries = _AbstractWorkspace.Query<Series>(expM);
          //  var query2 = from seri in infseries
          //  select new InfOracleStudyModel
          //  {
          //                   Key = seri.SeriesKey

          //  };


          //  var seriq = query2  
          //       .Skip(0)
          //       .Take(50)
          //       .ToList();

          //  if (seriq.Count > 0)
          //  {
          //      s = new InfManuelKeyConditionFilter
          //      {

          //          Key = Convert.ToInt32(seriq[0].Key)
              


          //      };
          //  }
          //  var expSeri = InfSeriesKeyCondition.GetInstance(s, 2);



          //  var infinstance = _AbstractWorkspace.Query<Instance>(expSeri);
          //  var query3 = from instance in infinstance

          //               select new InfOracleStudyModel
          //               {
          //                   Key = instance.InstanceKey

          //               };

          //  var instanceq = query3
          //  .Skip(0)
          //  .Take(50)
          //  .ToList();

          //  if (instanceq.Count > 0)
          //  {
          //      s = new InfManuelKeyConditionFilter
          //      {

          //          Key = Convert.ToInt32(instanceq[0].Key)



          //      };
          //  }

          //  var expinstance = InfSeriesKeyCondition.GetInstanceLoc(s, 2);


          //  var infinstanceLoc = _AbstractWorkspace.Query<Instanceloc>(expinstance);
          //  var query5= from qinstanceLoc in infinstanceLoc

          //              select new InfOracleViewModel
          //              {
          //                   VolumeCode = qinstanceLoc.VolumeCode,
          //                   VolumePathname = qinstanceLoc.Pathname,
          //                   Pathname = qinstanceLoc.Pathname


          //              };

          //  var instaloc = query5
          //  .Skip(0)
          //  .Take(50)
          //  .ToList();

          //  if (instaloc.Count > 0)
          //  {
          //      s = new InfManuelKeyConditionFilter
          //      {

          //          VolumeCode = instaloc[0].VolumeCode



          //      };
          //  }




          //  var instance1 = infinstanceLoc.ToList();


          //  var exp_volume = InfSeriesKeyCondition.GetVolume(s, 2);


          //  var infvolume = _AbstractWorkspace.Query<Volume>(exp_volume);
          //  var query6 = from qinstanceLoc in infinstanceLoc
          //               select new InfOracleViewModel
          //               {
          //                   VolumeCode = qinstanceLoc.VolumeCode,
          //                   VolumePathname = qinstanceLoc.Pathname,
          //                   Pathname = qinstanceLoc.Pathname


          //               };

          //  var volume = query6
          //.Skip(0)
          //.Take(50)
          //.ToList();

          //  if (volume.Count > 0)
          //  {
          //      s = new InfManuelKeyConditionFilter
          //      {

          //          VolumeCode = volume[0].VolumeCode



          //      };
          //  }





            //var infimage = _AbstractWorkspace.Query<Image>();
            var infstudy = _AbstractWorkspace.Query<Study>(exp);
            var infseries = _AbstractWorkspace.Query<Series>(exp1);
            var infinstance = _AbstractWorkspace.Query<Instance>();
            var infinstanceLoc = _AbstractWorkspace.Query<Instanceloc>();
            var infvolume = _AbstractWorkspace.Query<Volume>();
            var query = from stdy in infstudy

                        from seri in infseries.Where(o => o.StudyKey == stdy.StudyKey)
                                           .Take(1)
                                           .DefaultIfEmpty()
                        from ins in infinstance.Where(o => o.SeriesKey == seri.SeriesKey)
                                          .Take(1)
                                          .DefaultIfEmpty()
                        from insloc in infinstanceLoc.Where(o => o.InstanceKey == ins.InstanceKey)
                                          .Take(1)
                                          .DefaultIfEmpty()
                        from vol in infvolume.Where(o => o.VolumeCode == insloc.VolumeCode)
                                          .Take(1)
                                          .DefaultIfEmpty()

                            //let seri = infseries.Where(o => o.StudyKey == stdy.StudyKey).FirstOrDefault()
                            //let ins =  infinstance.Where(o => o.SeriesKey == seri.SeriesKey).FirstOrDefault()
                            //let insloc =  infinstanceLoc.Where(o => o.InstanceKey == ins.InstanceKey).FirstOrDefault()
                            //let vol =  infvolume.Where(o => o.VolumeCode == insloc.VolumeCode).FirstOrDefault()
                            //let img = infimage.Where(o => o.InstanceKey == insloc.InstanceKey).FirstOrDefault()
                            //join seri in infseries on stdy.StudyKey equals seri.StudyKey into t

                            //join ins in infinstance on seri.SeriesKey equals ins.SeriesKey
                            //join insloc in infinstanceLoc on ins.InstanceKey equals insloc.InstanceKey
                            //join vol in infvolume on insloc.VolumeCode equals vol.VolumeCode
                            //join img in infimage on insloc.InstanceKey equals img.InstanceKey

                        select new InfOracleViewModel
                        {
                            StudyKey = stdy.StudyKey,
                            PatientId = stdy.PatientId,
                            PatientName = stdy.PatientName,
                            PatientSex = stdy.PatientSex,
                            PatientBirthDttm = stdy.PatientBirthDttm.Value,
                            StudyInstanceUid = stdy.StudyInstanceUid,
                            StudyDttm = stdy.StudyDttm,
                            AccessNo = stdy.AccessNo,
                            Institution = stdy.Institution,
                            SeriesCount = stdy.SeriesCount,
                            InstanceCount = stdy.InstanceCount,
                            Modalities = stdy.Modalities,
                            Pathname = insloc.Pathname,
                            Filename = insloc.Filename,
                            VolumeCode = vol.VolumeCode,
                            VolumeType = vol.VolumeType,
                            VolumeStat = vol.VolumeStat,
                            VolumePathname = vol.Pathname,
                            ModifyDttm = stdy.ModifyDttm.Value,
                            CreationDttm = stdy.CreationDttm.Value,
                            StudyDesc = stdy.StudyDesc,
                            InfMergeKey = stdy.MergeKey,
                            SeriesInfo = seri.SeriesInfo,
                          
                                //Durum = Durum
                            //VolumeCodeinsloc = insloc.VolumeCode 
                          


                        };

            //var g = query.ToList();

            return query;



        }



        public IQueryable<InfOracleViewModel> Query(InfStudyConditionFilter f, InfSerieConditionFilter s)
        {
            var exp = InfStudyCondition.Get(f);
            var exp1 = InfSeriesCondition.Get(s);
            return Query(exp,exp1);

        }

        public IQueryable<InfOracleViewModel> QueryM(InfStudyConditionFilter f, InfSerieConditionFilter s)
        {
            var exp = InfStudyCondition.Get(f);
            var exp1 = InfSeriesCondition.Get(s);
            return QueryManuelCek(exp, exp1,f);

        }




    }
}
