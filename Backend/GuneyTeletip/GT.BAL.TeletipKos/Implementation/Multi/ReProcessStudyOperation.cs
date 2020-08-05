using GT.Core.Settings;
using GT.Repository.Models.View.Composite;
using System.Threading;
using Teletip.SorgulamaServis;

namespace GT.Job.Implementation
{
    public class ReProcessStudyOperation : BatchOperation<ReprocessViewModel, OperationResult<ReprocessStudyOperationResult>, ReprocessStudyOperationResult>
    {
        STMService STMService { get; set; }

        public ReProcessStudyOperation() : base(new OperationSettings(4, 4))
        {
            var globalSettings = AppSettings.GetCurrent();
            var stmSettings = globalSettings.STM;
            var token = new STMTokenProvider(stmSettings.BASEADDRESS, stmSettings.userTokenName, stmSettings.userTokenPassword, stmSettings.HBYS_PACS_ResourceOwnerClient, stmSettings.identityServerBaseUri).GetToken();
            STMService = new STMService(token, stmSettings.BASEADDRESS);

        }
        public override OperationResult<ReprocessStudyOperationResult> DoSingle(ReprocessViewModel indata)
        {
            var medulaInsID = int.Parse(indata.MedulaInstitutionID);
            var list = STMService.ReProcessStudy(medulaInsID, indata.AccessionNumber);
            var t = new OperationResult<ReprocessStudyOperationResult>();
            t.IsSuccess = true;
            t.Data = new ReprocessStudyOperationResult(list.ToArray());
            return t;
        }
    }
}
