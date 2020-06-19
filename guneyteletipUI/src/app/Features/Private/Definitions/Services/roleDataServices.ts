import { ApiDataService } from 'src/app/Shared/Services/Api/apiDataService';
import { Grid } from 'src/app/Shared/Models/UIControls/grid-control';
import { Observable } from 'rxjs';
import { roleViewFilter } from '../Models/RoleViewFilter';
import { roleViewModel } from '../Models/RoleViewModel';
import { saveRoleModel } from '../Models/saveRoleModel';
import { roleModel } from '../Models/roleModel';
import { permissionViewModel } from '../Models/permissionViewModel';
import { savePermissionModel } from '../Models/savePermissionModel';

export class roleDataServices {
  constructor(private apiDataService: ApiDataService) { }
  public GetRoleList(model: Grid.GridInputModel<roleViewModel>): Observable<Grid.GridOutputModel<roleViewFilter>> {
    return this.apiDataService.callDataService('Role/GetRoleList', model);
  }
  public save(model: saveRoleModel): Observable<number> {
    return this.apiDataService.callDataService('Role/Save', model);
  }
  public Delete(model: roleModel): Observable<number> {
    return this.apiDataService.callDataService('Role/Delete', model);
  }
  public GetPermissionList(): Observable<Array<permissionViewModel>> {
    return this.apiDataService.callDataService('Role/GetPermissionList', undefined);
  }
  public GetPermissionListByRoleID(model: roleModel): Observable<number> {
    return this.apiDataService.callDataService('Role/GetPermissionListByRoleID', model);
  }
  public SavePermission(model: savePermissionModel): Observable<number> {
    return this.apiDataService.callDataService('Role/SavePermission', model);
  }
}
