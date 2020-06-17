//using IdentityModel.Client;
using IdentityModel.Client;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Teletip.SorgulamaServis
{
    public class STMTokenProvider : ISTMTokenProvider
    {
        public const string ServerAddress = "https://sec.teletip.saglik.gov.tr";

        private string tokenUserName { get; set; }

        private string tokenPassword { get; set; }
        private string BaseAddress { get; set; }

        private string tokenHBYSPACSViewerClient { get; set; }

        private string tokenidentityServerBaseUri { get; set; }
        

        public STMTokenProvider(string baseAddress, string tokenuserName, string tokenpassword,string HBYSPACSViewerClient,string identityServerBaseUri)
        {
            BaseAddress = baseAddress;
            this.tokenUserName = tokenuserName;
            this.tokenPassword = tokenpassword;
            this.tokenHBYSPACSViewerClient = HBYSPACSViewerClient;
            this.tokenidentityServerBaseUri = identityServerBaseUri;
        }






        public TokenResponse GetToken()
        {
   
            var tokenClient = new TokenClient($"{tokenidentityServerBaseUri}/connect/token", "HBYS_PACS_ResourceOwnerClient", tokenHBYSPACSViewerClient);
            tokenClient.BasicAuthenticationHeaderStyle = BasicAuthenticationHeaderStyle.Rfc2617;
            var tokenResponse = tokenClient.RequestResourceOwnerPasswordAsync(tokenUserName, tokenPassword, scope: "openid profile custom.profile Common.WebApi").Result;
            return tokenResponse;
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