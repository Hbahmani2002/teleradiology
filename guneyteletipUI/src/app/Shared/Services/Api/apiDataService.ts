import { Injectable } from '@angular/core';
import { of, Observable } from 'rxjs';
import { map, catchError, switchMap } from 'rxjs/operators';
import { ApiService } from './apiService';
@Injectable({
  providedIn: 'root'
})
export class ApiDataService {
  constructor(private apiService: ApiService) {

  }

  private callDataService(serviceName: string, params: any): Observable<any> {
    let token = "";
    return this.apiService.callPostService_Middle(serviceName, params, token).pipe(
      switchMap(res => {
        return this.onSuccessData(res);
      }),
      catchError(err => {
        return this.onFail(err);
      })
    );
    ;
  }

  onFail(err: any): any {
    var erData = err.error
    if (erData) {
      console.log(erData);
      if (erData.TypeVal == 2) {
        //this.authentication.redirectToLogin();
        return;
      }
      if (erData.Exception) {
        var message = erData.Exception.ClassName + ":" + erData.Exception.Message;
        //this.toastr.error(message);
      }
      return of(undefined);
    }
    else {
      console.log(err);
    }
  }
  onSuccessData(res: any): any {
    //if (!this.authentication.isAuthenticated(res))
    //  this.authentication.redirectToLogin()
    //let data: any = res;
    //return of(data.Data);
    return of(res);
  }
}











