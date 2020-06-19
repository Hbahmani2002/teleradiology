using GT.DataService.Model;
using GT.Repository.Models.View;
using GT.UI.WebApi.Models;
using GT.UI.WebApi.Models.KosModel;
using GT.UTILS.GRID;
using System.Collections.Generic;

namespace GT.UI.WebApi.Controllers
{
    public interface IKosController
    {
        ServiceResult<int> CreateKos(Gridable<InfStudyFilter> parms);
        ServiceResult<int> DeleteKos(Gridable<InfStudyFilter> parms);
        ServiceResult<string> ExportExcel(Gridable<InfStudyFilter> parms);
        ServiceResult<InfStudyViewModel> GetByID(KosModel model);
        ServiceResult<List<KosEnumTypeViewModel>> GetEnumTypeList();
        ServiceResult<List<KosHistoryModel>> GetKosHistoryByStudyID(KosHistoryModel model);
        ServiceResult<PagingResult<InfStudyViewModel>> GetKosList(Gridable<InfStudyFilter> parms);
        ServiceResult<List<KosEnumTypeViewModel>> GetModalityList();
        ServiceResult<int> ReprocessKos(Gridable<InfStudyFilter> parms);
        ServiceResult<int> UpdateReadKos(Gridable<InfStudyFilter> parms);
    }
}