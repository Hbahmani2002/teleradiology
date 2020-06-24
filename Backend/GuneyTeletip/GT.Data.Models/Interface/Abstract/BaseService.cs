using Gt.PERSISTANCE;

namespace GT.SERVICE
{
    public class BaseService
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
    }
}