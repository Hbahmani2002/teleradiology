using GT.DataService.Model;
using GT.Repository.Models.Filter;
using GT.Repository.Models.View;
using GT.UI.WebApi.Models;
using GT.UI.WebApi.Models.UserModel;
using GT.UTILS.GRID;
using System.Collections.Generic;

namespace GT.UI.WebApi.Controllers
{
    public interface IKosController
    {
        ServiceResult<PagingResult<object>> GetModalityList();
        ServiceResult<PagingResult<InfStudyViewModel>> GetKosList(Gridable<InfStudyFilter> parms);
        ServiceResult<int> CreateKos(Gridable<InfStudyFilter> parms);
        ServiceResult<int> DeleteKos(Gridable<InfStudyFilter> parms);
        ServiceResult<int> ReprocessKos(Gridable<InfStudyFilter> parms);
        ServiceResult<int> UpdateReadKos(Gridable<InfStudyFilter> parms);
        ServiceResult<string> ExportExcel(Gridable<InfStudyFilter> parms);
    }
}