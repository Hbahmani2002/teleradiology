import { ApiDataService } from 'src/app/Shared/Services/Api/apiDataService';
import { Grid } from 'src/app/Shared/Models/UIControls/grid-control';
import { Observable } from 'rxjs';


import { userViewFilter } from '../Models/UserViewFilter';
import { userViewModel } from '../Models/UserViewModel';
import { userSaveModel } from '../Models/UserSaveModel';

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
    return this.apiDataService.callDataService('User/Save', model);
  }
  public getByID(model: userUIModel): Observable<userViewModel> {
    return this.apiDataService.callDataService('User/GetByID', model);
  }
  public delete(model: userUIModel): Observable<number> {
    return this.apiDataService.callDataService('User/Delete', model);
  }
  public getRolList(): Observable<Array<roleViewModel>> {
    return this.apiDataService.callDataService('User/GetRolList', undefined);
  }
  public getRoleByID(model: userUIModel): Observable<number> {
    return this.apiDataService.callDataService('User/GetRoleByID', model);
  }
  public saveRol(model: saveRolUIModel): Observable<number> {
    return this.apiDataService.callDataService('User/SaveRol', model);
  }
  public getTenantList(): Observable<Array<tenantViewModel>> {
    return this.apiDataService.callDataService('User/GetTenantList', undefined);
  }
  public saveTenant(model: saveTenantUIModel): Observable<number> {
    return this.apiDataService.callDataService('User/SaveTenant', model);
  }
  public GetTenantListByUserID(model: userUIModel): Observable<number> {
    return this.apiDataService.callDataService('User/GetTenantListByUserID', model);
  }
}
