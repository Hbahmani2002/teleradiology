﻿using Gt.PERSISTANCE;
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
        }
        public long Save(LogType type, string desc)
        {
            var log = new AppLog();
            log.LogType = (int)type;
            log.TimeCreated = DateTime.Now;
            log.FkUserCreated = Context == null ? (long?)null : Context.UserInfo.UserIDCurrent;
            log.Desc1 = desc.Substring(0, 3999);
            appLog.Add(log);
            _Workspace.CommitChanges();
            return log.Pk;
        }
    }
}
