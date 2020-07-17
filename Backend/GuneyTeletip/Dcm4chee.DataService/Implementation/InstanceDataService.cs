using Dcm4chee.Repository.Implementation;
using Dcm4chee.Repository.Models;
using Gt.PERSISTANCE;
using GT.SERVICE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dcm4chee.DataService
{
    public class InstanceDataService : BaseService
    {
        AbstractWorkspace _Workspace;
        InstanceRepository instanceRepository;
        public InstanceDataService(IBussinessContext context) : base(context)
        {
            _Workspace = Dcm4cheeWorkspaceFactory.Create(false);
            instanceRepository = new InstanceRepository(_Workspace);
        }

        public List<InstanceViewModel> Query() {
            return instanceRepository.InstanceList().ToList();
        }
    }
}
