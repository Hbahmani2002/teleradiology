using Gt.PERSISTANCE;
using System;

namespace GT.SERVICE
{
    public abstract class BaseService:IDisposable
    {
        public AbstractWorkspace _Workspace { get; set; }
        public BaseService(IBussinessContext context, AbstractWorkspace workspace)
        {
            Context = context;
            _Workspace = workspace;
        }
        public BaseService(IBussinessContext context)
        {
            Context = context;
        }

        public IBussinessContext Context { get; }

        public void Dispose()
        {
            if (_Workspace == null)
                return;
            _Workspace.Dispose();
        }
    }
}