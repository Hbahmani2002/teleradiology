import { Injectable } from '@angular/core';
import { of, Observable } from 'rxjs';
import { map, catchError, switchMap } from 'rxjs/operators';
import { Token } from '@angular/compiler/src/ml_parser/lexer';
import { tokenService } from '../Util/tokenService';
import { httpService } from '../Util/httpService';
@Injectable({
  providedIn: 'root'
})
export class ApiDataService {
  public token: string;
  constructor(private httpService: httpService, private tokenService : tokenService) {

  }

  private callDataService(serviceName: string, params: any): Observable<any> {
    let token = this.tokenService.getToken();
    return this.httpService.callPostService_Middle(serviceName, params, token).pipe(
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











