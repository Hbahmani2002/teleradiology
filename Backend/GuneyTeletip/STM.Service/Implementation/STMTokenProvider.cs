//using IdentityModel.Client;
using IdentityModel.Client;
using System;
using System.IO;

namespace Teletip.SorgulamaServis
{
    public class STMTokenProvider : ISTMTokenProvider
    {
        public const string ServerAddress = "https://sec.teletip.saglik.gov.tr";

        private string UserName { get; set; }

        private string Password { get; set; }
        private string BaseAddress { get; set; }
        public STMTokenProvider(string baseAddress, string userName, string password)
        {
            BaseAddress = baseAddress;
            this.UserName = userName;
            this.Password = password;
        }

        public TokenResponse GetToken()
        {
            //https://damienbod.com/2019/05/10/handling-access-tokens-for-private-apis-in-asp-net-core/
            //var tokenClient = new TokenClient($"{BaseAddress}/connect/token", "HBYS_PACS_ResourceOwnerClient", new TokenClientOptions() { 

            //});
            //tokenClient.BasicAuthenticationHeaderStyle = BasicAuthenticationHeaderStyle.Rfc2617;
            //var tokenResponse = tokenClient.RequestResourceOwnerPasswordAsync(tokenResponseUserName, tokenResponsePassword, scope: "openid profile custom.profile Common.WebApi").Result;

            //if (tokenResponse.IsError)
            //{
            //    throw new Exception($"Token Alaınamadi:{tokenResponse.Raw},{tokenResponseUserName},{tokenResponsePassword}");
            //}
            //else
            //{
            //    SaveToken(tokenResponse);
            //}
            return null;
        }
        //public TokenResponse GetToken()
        //{
        //    var lastToken = GetLastToken();
        //    if (lastToken != null)
        //    {
        //        return lastToken;
        //    }
        //    var tokenClient = new TokenClient($"{IdentityServerBaseUri}/connect/token", "HBYS_PACS_ResourceOwnerClient", tokenClientPassword);
        //    tokenClient.BasicAuthenticationHeaderStyle = BasicAuthenticationHeaderStyle.Rfc2617;
        //    var tokenResponse = tokenClient.RequestResourceOwnerPasswordAsync(tokenResponseUserName, tokenResponsePassword, scope: "openid profile custom.profile Common.WebApi").Result;

        //    if (tokenResponse.IsError)
        //    {
        //        throw new Exception($"Token Alaınamadi:{tokenResponse.Raw},{tokenResponseUserName},{tokenResponsePassword}");
        //    }
        //    else
        //    {
        //        SaveToken(tokenResponse);
        //    }

        //    return tokenResponse;
        //}


    }
}