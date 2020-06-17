using GT.DataService.Model;
using GT.Repository.Models.Filter;
using GT.Repository.Models.View;
using GT.UI.WebApi.Models;
using GT.UI.WebApi.Models.UserModel;
using MEDLIFE.UTILS.GRID;
using System.Collections.Generic;

namespace GT.UI.WebApi.Controllers
{
    public interface IUserController
    {
        ServiceResult<int> Delete(UserUIModel model);
        ServiceResult<UserViewModel> GetByID(UserUIModel model);
        ServiceResult<int> GetPermission(UserView model);
        ServiceResult<int> GetRoleByID(UserUIModel model);
        ServiceResult<List<RoleViewModel>> GetRolList();
        ServiceResult<int> GetTenantByID(UserUIModel model);
        ServiceResult<PagingResult<TenantViewModel>> GetTenantList(Gridable<TenantViewFilter> parms);
        ServiceResult<PagingResult<UserViewModel>> GetUserList(Gridable<UserViewFilter> parms);
        ServiceResult<int> SaveRol(SaveRolUIModel model);
        ServiceResult<int> SaveTenant(SaveTenantUIModel model);
    }
}