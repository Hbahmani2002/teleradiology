import { ApiDataService } from 'src/app/Shared/Services/Api/apiDataService';
import { Grid } from 'src/app/Shared/Models/UIControls/grid-control';
import { UserViewFilter } from '../Models/UserViewFilter';
import { UserViewModel } from '../Models/UserViewModel';
import { UserView } from '../Models/UserView';
import { of, Observable } from 'rxjs';
import { map, catchError, switchMap } from 'rxjs/operators';
export class userDataServices {

  constructor(private apiDataService: ApiDataService) { }

  public functionName(): Observable<boolean> {
    return this.apiDataService.callDataService('Service/Name', undefined);
  }
  public getUserList(model: Grid.GridInputModel<UserViewFilter>): Observable<Grid.GridOutputModel<UserViewModel>> {
    debugger;
    return this.apiDataService.callDataService('User/GetUserList', model);
  }
  public save(model: UserView): Observable<number> {
    return this.apiDataService.callDataService('Service/Save', undefined);
  }
}