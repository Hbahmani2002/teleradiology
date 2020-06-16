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
        
        public static ServiceResult<T> Ok<T>(T data)
        {
            var sc = new ServiceResult<T>();
            sc.TypeVal = ServiceResultType.SUCCESS;
            sc.Data = data;
            return sc;
        }
        public static ServiceResult<Exception> Exception(Exception data)
        {
            var sc = new ServiceResult<Exception>();
            sc.TypeVal = ServiceResultType.FAIL;
            sc.Exception = data;
            sc.Message = data.Message;
            return sc;
        }
        public static ServiceResult<T> OkData<T>(T data)
        {
            var sc = new ServiceResult<T>();
            sc.TypeVal = ServiceResultType.SUCCESS_WITH_DATA;
            sc.Data = data;
            return sc;
        }
        public static ServiceResult<T> Fail<T>(T data)
        {
            var sc = new ServiceResult<T>();
            sc.TypeVal = ServiceResultType.FAIL;
            sc.Data = data;
            return sc;
        }
    }
}
