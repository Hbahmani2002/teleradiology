//using IdentityModel.Client;
using System;
using System.IO;

namespace Teletip.SorgulamaServis
{
    public class TokenProvider
    {
        public string TokenSavePath => "token.txt";
        public string tokenClientPassword { get; set; }
        

      
        public string tokenResponseUserName { get; set; }

        public string tokenResponsePassword { get; set; }


        public string IdentityServerBaseUri
        {
            get
            {

                return "https://sec.teletip.saglik.gov.tr";
            }
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

        //private void SaveToken(TokenResponse tokenResponse)
        //{
        //    File.Delete(TokenSavePath);
        //    File.WriteAllText(TokenSavePath, tokenResponse.Raw);
        //}

        //public TokenResponse GetLastToken()
        //{
        //    if (!File.Exists(TokenSavePath))
        //        return null;
        //    var txt = File.ReadAllText(TokenSavePath);
        //    var dt = File.GetCreationTime(TokenSavePath);

        //    var token = new TokenResponse(txt);
        //    var isValid = dt.AddSeconds(token.ExpiresIn - 2) > DateTime.Now;
        //    if (isValid)
        //    {
        //        return token;
        //    }
        //    return null;
        //}
    }
}