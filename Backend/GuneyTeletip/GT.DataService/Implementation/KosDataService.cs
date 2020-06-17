using MEDLIFE.PERSISTANCE;
using MEDLIFE.SERVICE;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT.DataService.Implementation
{
    public class KosDataService : BaseService
    {
        AbstractWorkspace _Workspace;
        public KosDataService(IBussinessContext context) : base(context)
        {
            _Workspace = WorkspaceFactory.Create(true);
        }
    }
}
