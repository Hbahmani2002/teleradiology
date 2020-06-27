using Gt.PERSISTANCE;
using GT.Repository.Implementation;
using GT.SERVICE;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Data.Service
{
    public class AppparameterDataService : BaseService
    {
        AppParameterRepository appParameterRepository;
        public AppparameterDataService() : this(null)
        {
        }
        public AppparameterDataService(IBussinessContext context) : base(context)
        {
            _Workspace = GTWorkspaceFactory.Create(true);
            appParameterRepository = new AppParameterRepository(_Workspace);
        }
    }
}
