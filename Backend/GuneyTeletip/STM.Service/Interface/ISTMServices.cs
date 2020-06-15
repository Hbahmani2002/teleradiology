using System;
using System.Collections.Generic;

namespace Teletip.SorgulamaServis
{
    public interface ISTMServices
    {
        List<DailyCreatedResult> GetDailyCreatedOrderList(int medulaInstitutionId, string modality, DateTime queryDate);
        List<DailyOrderResult> GetDailyOrderList(int _medulaInstitutionId, string _modality, DateTime _queryDate);
        List<DailyStudyResult> GetDailyStudyList(int _medulaInstitutionId, string _modality, DateTime _queryDate);
        string GetImageLink(string CitizenId, string AccessionNo, string RequestingCitizenId);
        List<MedulaRegistrationFailedResult> GetMedulaRegistrationFailedOrderList(string _medulaInstitutionId, string _modality, DateTime _startDateTime, DateTime _endDateTime);
        List<string> GetNonMatchingOrderList(string _medulaInstitutionId, string _modality, DateTime _startDateTime, DateTime _endDateTime);
        List<string> GetNonMatchingStudyList(int _medulaInstitutionId, DateTime _startDateTime, DateTime _endDateTime);
        List<PatientResult> GetPatientOrderList(int _medulaInstitutionId, string _citizenId);
        List<PreviousStudiesResult> GetPreviousStudies(int medulaInstitutionId, string patientCitizenId, string sutCode, string doctorCitizenId);
        List<RemoveKosResult> GetRemoveKos(int medulaInstitutionId, string accessionNumber, string studyInstanceUID);
        List<string> ReProcessStudy(int medulaInstitutionId, string accessionNumber);
        List<StatusForAccessionNumberResult> GetOrderStatusForAccessionNumberList(int medulaInstitutionId, List<string> accessionNumber);
    }
}