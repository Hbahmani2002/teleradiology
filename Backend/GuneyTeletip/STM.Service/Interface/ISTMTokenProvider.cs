//using IdentityModel.Client;
using IdentityModel.Client;

namespace Teletip.SorgulamaServis
{
    public interface ISTMTokenProvider
    {
        TokenResponse GetToken();
    }
}