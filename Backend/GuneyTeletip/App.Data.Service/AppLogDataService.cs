using Gt.PERSISTANCE;
using GT.Persistance.Domain.Models;
using GT.Repository.Implementation;
using GT.SERVICE;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Data.Service
{
    public class AppLogDataService : BaseService
    {
        AbstractWorkspace _Workspace;
        AppLogRepository appLog;
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
        }
        public long Save(LogType type, string desc)
        {
            var log = new AppLog();
            log.LogType = (int)type;
            log.TimeCreated = DateTime.Now;
            log.FkUserCreated = Context == null ? (long?)null : Context.UserInfo.UserIDCurrent;
            log.Desc1 = desc;
            appLog.Add(log);
            _Workspace.CommitChanges();
            return log.Pk;
        }
    }
}
