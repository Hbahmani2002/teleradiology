using GT.DataService.Model;
using GT.Repository.Implementation;
using GT.Repository.Models.View;
using MEDLIFE.PERSISTANCE;
using MEDLIFE.SERVICE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GT.DataService.Implementation
{
    public class AuthenticationDataService : BaseService
    {
        AbstractWorkspace _Workspace;
        UsrUserLoginRepository usrUserLoginRepository;
        public AuthenticationDataService(IBussinessContext context) : base(context)
        {
            _Workspace = WorkspaceFactory.Create(true);
            usrUserLoginRepository = new UsrUserLoginRepository(_Workspace);
        }

        public ServiceResult<UserLoginViewModel> Login()
        {
            //var user = usrUserLoginRepository.Query(o=> o.UserName==model.UserName && o.Password==model.Password).FirstOrDefault();
            //if (user == null)
            //    throw new Exception("Kullanıcı Bulunamadı");
            //else
            //{
            //    var item = new UserLoginViewModel
            //    {
            //        UserID= user.Pk,
            //        UserName=user.UserName
            //    };
            //    return item;
            //}
            var item = new UserLoginViewModel
            {
                UserID = 1,
                UserName = "Zehra"
            };
            var serviceResult = new ServiceResult<UserLoginViewModel>
            {
                Data = item,
                Message = "Deneme Message",
                Type = "Type0"
            };
            return serviceResult;
        }

        public ServiceResult<PermissionViewModel> GetPermission()
        {
            var item = new PermissionViewModel
            {
                Login=true
            };
            var serviceResult = new ServiceResult<PermissionViewModel>
            {
                Data = item,
                Message = "Deneme Message",
                Type = "Type0"
            };
            return serviceResult;
        }
    }
}
