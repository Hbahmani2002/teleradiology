using Gt.PERSISTANCE;
using GT.Repository.Implementation;
using GT.Repository.Implementation.Composite;
using GT.Repository.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GT.DataService.Implementation
{
    public class AuthenticationDataService
    {
        AbstractWorkspace _Workspace;
        UserLoginRepository userLoginRepository;
        UserCompositeRepository userCompositeRepository;
        public AuthenticationDataService()
        {
            _Workspace = GTWorkspaceFactory.Create();
            userLoginRepository = new UserLoginRepository(_Workspace);
            userCompositeRepository = new UserCompositeRepository(_Workspace);
        }

        public UserLoginViewModel Login(string kullaniciAdi, string sifre)
        {
            var user = userLoginRepository.GetByUserNameAndPassword(kullaniciAdi, sifre);
            if (user == null)
                return null;
            var roleList = userCompositeRepository.RoleList();
            var item = new UserLoginViewModel
            {
                UserID=user.Pk,
                UserName=user.UserName,
                RoleList= roleList.Where(x => x.UserID == user.Pk).Select(x => x.RoleName).ToArray()
            };
            return item;
        }
    }
}
