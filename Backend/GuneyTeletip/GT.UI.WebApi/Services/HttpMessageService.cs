using GT.DataService.Implementation;
using GT.Repository.Models.View;
using GT.UI.WebApi.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GT.UI.WebApi.Implementation
{
    public class HttpMessageService
    {
        public static ServiceResult<T> ServiceResult<T>(T data)
        {
            var sc = new ServiceResult<T>();
            sc.Data = data;
            return sc;
        }
    }
}
