//using IdentityModel.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Teletip.SorgulamaServis
{
    public class STMServices : ISTMServices
    {
        private  STMServiceParameter ServiceName_GetPatientOrderList = new STMServiceParameter("GetPatientOrderList");
        private  STMServiceParameter ServiceName_GetNonMatchingOrderList = new STMServiceParameter("GetNonMatchingOrderList", "nonMatchingParameter");
        private  STMServiceParameter ServiceName_GetNonMatchingStudyList = new STMServiceParameter("GetNonMatchingStudyList", "nonMatchingParameter");
        private  STMServiceParameter ServiceName_GetMedulaRegistrationFailedOrderList = new STMServiceParameter("GetMedulaRegistrationFailedOrderList", "nonMatchingParameter");
        private  STMServiceParameter ServiceName_GetDailyOrderList = new STMServiceParameter("GetDailyOrderList");
        private  STMServiceParameter ServiceName_GetDailyStudyList = new STMServiceParameter("GetDailyStudyList?parameter");
        private  STMServiceParameter ServiceName_GetOrderStatusForAccessionNumberList = new STMServiceParameter("GetOrderStatusForAccessionNumberList");
        private  STMServiceParameter ServiceName_GetDailyCreatedOrderList = new STMServiceParameter("GetDailyCreatedOrderList");
        private  STMServiceParameter ServiceName_RemoveKos = new STMServiceParameter("RemoveKos", httpMethod: "POST");
        private  STMServiceParameter ServiceName_GetPreviousStudies = new STMServiceParameter("GetPreviousStudies");

        //public STMServiceParamter ServiceName_ReProcessStudy = new STMServiceParamter("ReProcessStudy");

        public string BaseAddress => "https://api.teletip.saglik.gov.tr/Common.WebApi/api/Integration/";



        public TokenProvider TokenProvider { get; set; }
        public STMServices(TokenProvider tokenProvider)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            TokenProvider = tokenProvider;
        }

        public List<PatientResult> GetPatientOrderList(int _medulaInstitutionId, string _citizenId)
        {
            var obj = CallApi<List<PatientResult>>(ServiceName_GetPatientOrderList, new
            {
                MedulaInstitutionId = _medulaInstitutionId,
                CitizenId = _citizenId
            });
            return obj;

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_medulaInstitutionId"></param>
        /// <param name="_modality"></param>
        /// <param name="_startDateTime"></param>
        /// <param name="_endDateTime"></param>
        /// <returns>AccNo List</returns>
        public List<string> GetNonMatchingOrderList(string _medulaInstitutionId, string _modality, DateTime _startDateTime, DateTime _endDateTime)
        {
            var obj = CallApi<List<string>>(ServiceName_GetNonMatchingOrderList, new
            {
                MedulaInstitutionId = _medulaInstitutionId,
                Modality = _modality,
                StartDateTime = _startDateTime,
                EndDateTime = _endDateTime
            });
            return obj;

        }



        public List<string> GetNonMatchingStudyList(int _medulaInstitutionId, DateTime _startDateTime, DateTime _endDateTime)
        {
            var obj = CallApi<List<string>>(ServiceName_GetNonMatchingStudyList, new
            {
                MedulaInstitutionId = _medulaInstitutionId,
                StartDateTime = _startDateTime,
                EndDateTime = _endDateTime
            });
            return obj;
        }



        public List<MedulaRegistrationFailedResult> GetMedulaRegistrationFailedOrderList(string _medulaInstitutionId, string _modality, DateTime _startDateTime, DateTime _endDateTime)
        {
            var obj = CallApi<List<MedulaRegistrationFailedResult>>(ServiceName_GetMedulaRegistrationFailedOrderList, new
            {
                MedulaInstitutionId = _medulaInstitutionId,
                Modality = _modality,
                StartDateTime = _startDateTime,
                EndDateTime = _endDateTime
            });
            return obj;
        }

        /// <summary>
        /// Teletıp sistemine gönderilen/gönderildiği düşünülen istem/tetkiklerin eşleşme, medulaya gönderim gibi durumlarını sorgulamak için GetOrderStatusForAccessionNumberList metodu kullanılır
        /// </summary>
        /// <param name="medulaInstitutionId"></param>
        /// <param name="accessionNumber"></param>
        /// <returns></returns>
        public List<StatusForAccessionNumberResult> GetOrderStatusForAccessionNumberList(int medulaInstitutionId, List<string> accessionNumber)
        {
            var obj = CallApi<List<StatusForAccessionNumberResult>>(ServiceName_GetOrderStatusForAccessionNumberList, new
            {
                MedulaInstitutionId = medulaInstitutionId,
                AccessionNumberList = accessionNumber,

            });
            return obj;


        }


        /// <summary>
        /// Teletip sisteminde başarılı olarak kaydedilen istemlere ait accession number ve modalite listesini sorgulamak için GetDailyOrderList metodu kullanılır.Sorgulama yapılan tarih HL7 içerisinde bildirilen randevu tarihidir.(ScheduleDate)
        /// </summary>
        /// <param name="_medulaInstitutionId"></param>
        /// <param name="_modality"></param>
        /// <param name="_queryDate"></param>
        /// <returns></returns>
        public List<DailyOrderResult> GetDailyOrderList(int _medulaInstitutionId, string _modality, DateTime _queryDate)
        {

            var obj = CallApi<List<DailyOrderResult>>(ServiceName_GetDailyOrderList, new
            {
                MedulaInstitutionId = _medulaInstitutionId,
                Modality = _modality,
                QueryDate = _queryDate

            });
            return obj;
        }




        public List<DailyStudyResult> GetDailyStudyList(int _medulaInstitutionId, string _modality, DateTime _queryDate)
        {
            var obj = CallApi<List<DailyStudyResult>>(ServiceName_GetDailyStudyList, new
            {
                MedulaInstitutionId = _medulaInstitutionId,
                Modality = _modality,
                StartDateTime = _queryDate

            });
            return obj;

        }

        public List<DailyCreatedResult> GetDailyCreatedOrderList(int medulaInstitutionId, string modality, DateTime queryDate)
        {

            var obj = CallApi<List<DailyCreatedResult>>(ServiceName_GetDailyCreatedOrderList, new
            {
                MedulaInstitutionId = medulaInstitutionId,
                Modality = modality,
                Querydate = queryDate

            });
            return obj;

        }


        public List<RemoveKosResult> GetRemoveKos(int medulaInstitutionId, string accessionNumber, string studyInstanceUID)
        {

            var obj = CallApi<List<RemoveKosResult>>(ServiceName_RemoveKos, new
            {
                MedulaInstitutionId = medulaInstitutionId,
                AccessionNumber = accessionNumber,
                StudyInstanceUID = studyInstanceUID

            });
            return obj;

        }

        public List<PreviousStudiesResult> GetPreviousStudies(int medulaInstitutionId, string patientCitizenId, string sutCode, string doctorCitizenId)
        {

            var obj = CallApi<List<PreviousStudiesResult>>(ServiceName_GetPreviousStudies, new
            {
                MedulaInstitutionId = medulaInstitutionId,
                PatientCitizenId = patientCitizenId,
                SutCode = sutCode,
                DoctorCitizenId = doctorCitizenId
            });
            return obj;

        }

        public List<string> ReProcessStudy(int medulaInstitutionId, string accessionNumber)
        {
            var obj = CallApi<List<string>>(new STMServiceParameter("ReProcessStudy", httpMethod: "POST"), new
            {
                MedulaInstitutionId = medulaInstitutionId,
                AccessionNumber = accessionNumber
            });
            return obj;
        }



        private string CallApi(STMServiceParameter serviceName, string paramObjJson)
        {
            

            //var tokenResponse = GetToken();

            var client = new HttpClient();
            //client.SetBearerToken(tokenResponse.AccessToken);
            HttpResponseMessage httpRes = null;
            if (serviceName.HttpMethod == "GET")
            {
                var inputParameter = $"{paramObjJson}";
                var address = $"{BaseAddress}{serviceName.ServiceName}?{serviceName.ParameterName}";
                var fullAddress = address + "=" + inputParameter;
                httpRes = client.GetAsync(fullAddress).Result;
            }
            else if (serviceName.HttpMethod == "POST")
            {
                var inputParameter = $"{serviceName.ServiceName}";
                httpRes = client.PostAsync(BaseAddress + inputParameter, new StringContent(paramObjJson, Encoding.UTF8, "application/json")).Result;
            }

            var resultJson = httpRes.Content.ReadAsStringAsync().Result;
            // var result = Task.FromResult(client.GetAsync(BaseAddress+
            //inputParameter).Result).Result.Content;
            //var resultJson = result.ReadAsStringAsync().Result;
            return resultJson;

        }

        //private TokenResponse GetToken()
        //{
        //    var tokenResponse = TokenProvider.GetToken();
        //    return tokenResponse;
        //}

        private T CallApi<T>(STMServiceParameter serviceName, object paramObj)
        {
            var paramObjJson = JsonConvert.SerializeObject(paramObj);

            var jsonResult = CallApi(serviceName, paramObjJson);
            try
            {
                var obj = JsonConvert.DeserializeObject<T>(jsonResult);
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"Servis Sonucu Hatalı ServiceName:{serviceName},Parameter:{paramObjJson},Return:{jsonResult}", ex);
            }
        }

        public string GetImageLink(string CitizenId, string AccessionNo, string RequestingCitizenId)
        {
            throw new NotImplementedException();
            //var token = GetToken();
            //return $"https://live.teletip.saglik.gov.tr/home/newguidservice?requestedCitizenId={CitizenId}&accessionNo={AccessionNo}&requestingCitizenId={RequestingCitizenId}&accessToken={token.AccessToken}";

        }
    }

}
