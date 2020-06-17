import { ApiDataService } from 'src/app/Shared/Services/Api/apiDataService';
import { Grid } from 'src/app/Shared/Models/UIControls/grid-control';
import { userViewFilter } from '../Models/UserViewFilter';
import { userViewModel } from '../Models/UserViewModel';
import { userSaveModel } from '../Models/UserSaveModel';
import { Observable } from 'rxjs';
import { userUIModel } from '../Models/UserUIModel';
import { roleViewModel } from '../Models/RoleViewModel';
import { saveRolUIModel } from '../Models/SaveRolUIModel';
import { tenantViewFilter } from '../Models/TenantViewFilter';
import { tenantViewModel } from '../Models/TenantViewModel';
import { saveTenantUIModel } from '../Models/SaveTenantUIModel';

export class userDataServices {

  constructor(private apiDataService: ApiDataService) { }

  public getUserList(model: Grid.GridInputModel<userViewFilter>): Observable<Grid.GridOutputModel<userViewModel>> {
    return this.apiDataService.callDataService('User/GetUserList', model);
  }
  public save(model: userSaveModel): Observable<number> {
    return this.apiDataService.callDataService('Service/Save', model);
  }
  public getByID(model: userUIModel): Observable<userViewModel> {
    return this.apiDataService.callDataService('Service/GetByID', model);
  }
  public delete(model: userUIModel): Observable<number> {
    return this.apiDataService.callDataService('Service/Delete', model);
  }
  public getRolList(): Observable<Array<roleViewModel>> {
    return this.apiDataService.callDataService('Service/GetRolList', undefined);
  }
  public getRoleByID(model: userUIModel): Observable<number> {
    return this.apiDataService.callDataService('Service/GetRoleByID', model);
  }
  public saveRol(model: saveRolUIModel): Observable<number> {
    return this.apiDataService.callDataService('Service/SaveRol', model);
  }
  public getTenantList(model: Grid.GridInputModel<tenantViewFilter>): Observable<Grid.GridOutputModel<tenantViewModel>> {
    return this.apiDataService.callDataService('User/GetTenantList', model);
  }
  public saveTenant(model: saveTenantUIModel): Observable<number> {
    return this.apiDataService.callDataService('Service/SaveTenant', model);
  }
  public getTenantByID(model: userUIModel): Observable<number> {
    return this.apiDataService.callDataService('Service/GetTenantByID', model);
  }
}
