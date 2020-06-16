using System.Security.Claims;

namespace GT.UI.WebApi.Implementation
{
    public class UserTokenModel
    {
        public UserTokenModel()
        {
        }

        public string UserName { get; set; }
        public long ID { get; set; }
    }
}