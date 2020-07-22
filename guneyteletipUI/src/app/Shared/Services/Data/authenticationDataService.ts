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
       
        return of(false);
      })
      //result is success
    );
  }

  // TODO: add Global error handling function 
  public getPermission(): Observable<boolean> {
    return this.apiDataService.callDataService('Authentication/GetPermission', undefined)
  }
  public GetUser(): Observable<object> {
    return this.apiDataService.callDataService('Authentication/GetUser', undefined)
  }
}
