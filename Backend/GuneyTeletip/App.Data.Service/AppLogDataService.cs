using Gt.PERSISTANCE;
using GT.Persistance.Domain.Models;
using GT.Repository.Implementation;
using GT.SERVICE;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppAbc.Data.Service
{
    public class AppLogDataService : BaseService
    {
        AppLogRepository appLog;
        public AppLogDataService() : this(null)
        {
        }
        public AppLogDataService(IBussinessContext context) : base(context)
        {
            _Workspace = GTWorkspaceFactory.Create(true);
            appLog = new AppLogRepository(_Workspace);
        }
        public enum LogType
        {
            OtomatikMakeKos = 1,
            OtomatikSentKos = 2,
            OtomatikStm = 3,
            BackGroundJobs = 10,
            InfOrclHata = 20,
            JobHata = 30,
            KosInstanceHata = 40,
            DoSingleBatchMakeKosBackroud=50,
            DoSingleBatchSendKosBackroud = 60,
            DoSingleBatchPahtIsNull = 70
        }
        public long Save(LogType type, string desc)
        {
            var log = new AppLog();
            log.LogType = (int)type;
            log.TimeCreated = DateTime.Now;
            log.FkUserCreated = Context == null ? (long?)null : Context.UserInfo.UserIDCurrent;
            log.Desc1 = desc.Length > 4000 ? desc.Substring(0, 4000) : desc;
            appLog.Add(log);
            _Workspace.CommitChanges();
            return log.Pk;
        }
    }
}
