using Gt.PERSISTANCE;
using GT.Persistance.Domain.Models;
using GT.Repository.Implementation;
using GT.SERVICE;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT.DataService.Implementation
{
    public class FileOperationDataService : BaseService
    {
        AbstractWorkspace _Workspace;
        AppFilePathRepository appFilePathRepository;
        public FileOperationDataService(IBussinessContext context) : base(context)
        {
            _Workspace = GTWorkspaceFactory.Create(false);
            appFilePathRepository = new AppFilePathRepository(_Workspace);
        }
        public long GetFilePathID(string fileName)
        {
            var filePath = new AppFilePath();
            filePath.Filename = fileName;
            filePath.TimeCreated = DateTime.Now;
            filePath.FkUserCreated = Context == null ? (long?)null : Context.UserInfo.UserIDCurrent;
            appFilePathRepository.Add(filePath);
            _Workspace.CommitChanges();
            return filePath.Pk;
        }
        public string GetFileNameByID(long fileID)
        {
            var filePath = appFilePathRepository.GetByID(fileID);
            return filePath.Filename;
        }
    }
}
