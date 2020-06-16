import { ApiDataService } from '../Api/apiDataService';
import { map, catchError, switchMap } from 'rxjs/operators';
import { Observable, of, Subscription } from 'rxjs';
import { apiResponseModel } from '../Api/Models/apiResponseModel';
export class authenticationDataService {
  constructor(private apiDataService: ApiDataService) {

  }
  public isLoggedIn() {
    return this.getPermission().pipe(
      switchMap(res => {
        return of(true);
      })
      ,

      catchError(err => {
        debugger;
        return of(false);
      })
      //result is success
    );
  }

  // TODO: add Global error handling function 
  public getPermission(): Observable<boolean> {
    return this.apiDataService.callDataService('Authentication/GetPermission', undefined)
  }
}
