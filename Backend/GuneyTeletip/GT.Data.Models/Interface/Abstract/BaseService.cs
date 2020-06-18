namespace GT.SERVICE
{
    public class BaseService
    {
       
        public BaseService(IBussinessContext context)
        {
            Context = context;
        }

        public IBussinessContext Context { get; }
    }
}