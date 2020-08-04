using NUnit.Framework;
using Teletip.SorgulamaServis;
using STM.Service.Test;
using System.Diagnostics.CodeAnalysis;
using System;
using GT.Core.Settings;
using System.Collections.Generic;
using GT.DataService.Implementation;
using GT.Repository.Models.View;
using GT.Repository.Implementation;
using Gt.PERSISTANCE;
using GT.SERVICE;
using GT.UI.WebApi.Controllers;
using GT.TeletipKos;

namespace STM.Service.Test
{
    public class STM_TEST
    {


        OrderStatusForAccessionNumberDataService _OrderStatusForAccessionNumberDataService;

        
        private IAbstractWorkspace _Workspace;


     

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            /*
            ClientPassword=HbPatT!180430
            UserName:protek_hbys@teletip.saglik.gov.tr
            ResponsePassword:1234Aasd?
             */



            int startGun = 0;
            int startAy = 0;
            int startYıl = 0;
            int finGun = 0;
            int finAy = 0;
            int finYıl = 0;

            startGun = 10;
            startAy = 05;
            startYıl = DateTime.Now.Year;

            finGun = DateTime.Now.Day;
            finAy = DateTime.Now.Month;
            finYıl = DateTime.Now.Year;

            DateTime StartDateTime;
            DateTime EndDateTime;


            StartDateTime = new DateTime(startYıl, startAy, startGun, 0, 0, 0);
            EndDateTime = new DateTime(finYıl, finAy, finGun, 0, 0, 0);


            var stmSettings = AppSettings.GetCurrent().STM;
            ISTMTokenProvider tk = new STMTokenProvider(stmSettings.BASEADDRESS, stmSettings.userTokenName, stmSettings.userTokenPassword, stmSettings.HBYS_PACS_ResourceOwnerClient, stmSettings.identityServerBaseUri);
            var stm_token = tk.GetToken();
            var service = new STMService(stm_token, stmSettings.BASEADDRESS);


          

            service.GetMedulaRegistrationFailedOrderList("11340028", "", StartDateTime, EndDateTime);
            service.GetMedulaRegistrationFailedOrderList("11340028", "", StartDateTime, EndDateTime);

            service.GetDailyStudyList(11340028, "", StartDateTime);
            service.GetDailyStudyList(11340028, "DX", StartDateTime);
            service.GetDailyStudyList(11340028, "", StartDateTime);

        }

        [Test]
        public void Test2()
        {
            /*
            ClientPassword=HbPatT!180430
            UserName:protek_hbys@teletip.saglik.gov.tr
            ResponsePassword:1234Aasd?
             */

            KosServiceTestController KosTest = new KosServiceTestController();
         var g = KosTest.CreateKosBackground(null);

            var es = g;

            //int startGun = 0;
            //int startAy = 0;
            //int startYıl = 0;
            //int finGun = 0;
            //int finAy = 0;
            //int finYıl = 0;

            //startGun = 10;
            //startAy = 05;
            //startYıl = DateTime.Now.Year;

            //finGun = DateTime.Now.Day;
            //finAy = DateTime.Now.Month;
            //finYıl = DateTime.Now.Year;

            //DateTime StartDateTime;
            //DateTime EndDateTime;


            //StartDateTime = new DateTime(startYıl, startAy, startGun, 0, 0, 0);
            //EndDateTime = new DateTime(finYıl, finAy, finGun, 0, 0, 0);


            //var stmSettings = AppSettings.GetCurrent().STM;
            //ISTMTokenProvider tk = new STMTokenProvider(stmSettings.BASEADDRESS, stmSettings.userTokenName, stmSettings.userTokenPassword, stmSettings.HBYS_PACS_ResourceOwnerClient, stmSettings.identityServerBaseUri);
            //var stm_token = tk.GetToken();
            //var service = new STMService(stm_token, stmSettings.BASEADDRESS);



            //List<string> AccessionNumber = new List<string>();
            //AccessionNumber.Add("C325532974");
            //var studyDataService = new StudyKosDataService();
            //var items = studyDataService.GetByID(Convert.ToInt32(58546));

            //var OrderStatusForAccessionNumberList = service.GetOrderStatusForAccessionNumberList(11340073, AccessionNumber);

            //var list = new List<OrderStatusForAccessionNumberViewModel>();

            //_OrderStatusForAccessionNumberDataService = new OrderStatusForAccessionNumberDataService(null);
            //foreach (var item in OrderStatusForAccessionNumberList)
            //{
            //    var model = new OrderStatusForAccessionNumberViewModel();


            //    model.FkTenant = items.TenantID;
            //    model.FkInfBatch = items.InfBatchID;
            //    model.FkKosStudy = items.ID;
            //    model.FkUserCreated = 0;
            //    model.FkUserModified = 0;
            //    model.Accessionnumber = item.AccessionNumber;
            //    model.Citizenid = item.CitizenId;
            //    model.Teletipstatus = item.TeletipStatus;
            //    model.Teletipstatusid = item.TeletipStatusId;
            //    model.Medulastatus = item.MedulaStatus;
            //    model.Medulastatusid = item.MedulaStatusId;
            //    model.Wadostatus = item.WadoStatus;
            //    model.Wadostatusid = item.WadoStatusId;
            //    model.Reportstatus = item.ReportStatus;
            //    model.Reportstatusid = item.ReportStatusId;
            //    model.Dosestatus = "";
            //    model.Dosestatusid = 0;
            //    model.Medulainstitutionid = item.MedulaInstitutionId;
            //    model.Sutcode = item.SutCode;
            //    model.Lastmedulasenddate = DateTime.Now;
            //    model.Medularesponsecode = item.MedulaResponseCode;
            //    model.Medularesponsemessage = item.MedulaResponseMessage;
            //    model.Scheduledate = item.ScheduleDate;
            //    model.Performeddate = item.PerformedDate;
            //    model.Error = item.Error;
            //    model.Patienthistorysearchstatus = "";
            //    model.Patienthistorysearchstatusid = 0;
            //    model.TimeCreated = DateTime.Now;
            //    model.TimeModified = null;




            //    list.Add(model);
            //}



            //_OrderStatusForAccessionNumberDataService.Save(list);


            //var s = OrderStatusForAccessionNumberList[0].AccessionNumber;



            //var items = _OrderStatusForAccessionNumberDataService.GetInfOracleList(filter);
            //var list = new List<InfOraclePostgreStudyViewModel>();



        }

        [Test]
        public void MakeKosJSON()
        {
            TeletipMakeKosService TeletipMakeKosService;
            var makeKosSetting = TeletipKosServiceSetting.GetCurrent().MakeKosSettings;
            TeletipMakeKosService = new TeletipMakeKosService(makeKosSetting);
            var dicomFilePathList = new MakeKosInstanceItem[]
            {
                new MakeKosInstanceItem("app/teletip_kos/E37678675/I01360665861.dcm")
            };
            var outputKosFilePath = "test_java/test.dcm";
            var accesNo = "C458733711";
            var patientID = "43603099026";
            var res = TeletipMakeKosService.MakeKosJSON(dicomFilePathList, outputKosFilePath, "", "", null, null, accesNo, patientID);
        }
    }
}