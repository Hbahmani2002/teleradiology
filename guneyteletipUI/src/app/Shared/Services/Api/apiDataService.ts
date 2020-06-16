import { Injectable } from '@angular/core';
import { of, Observable } from 'rxjs';
import { map, catchError, switchMap } from 'rxjs/operators';
import { Token } from '@angular/compiler/src/ml_parser/lexer';
import { tokenService } from '../Util/tokenService';
import { httpService } from '../Util/httpService';
import { parameters } from '../../Consts/parameters';
import { apiResponseModel } from './Models/apiResponseModel';
@Injectable({
  providedIn: 'root'
})
export class ApiDataService {

  constructor(private httpService: httpService, private tokenService : tokenService) {

  }

  public callDataService(serviceName: string, params: any): Observable<any> {    
    let token = this.tokenService.getToken();
    let serverAdress = parameters.serverAddress;
    let serviceUrl = serverAdress + serviceName;
    return this.httpService.callPostService_Middle(serviceUrl, params, token).pipe(
      switchMap(res => {
        return this.onSuccessData(res);
      }),
      catchError(err => {
        throw "Hata var networke bak..";        
      })
    );
    ;
  }

 private onFail(err: any): any {
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
  private onSuccessData(res: any): any {    
    let model = apiResponseModel.parse(res);
    console.log("TODO success control");
    //if (!this.authentication.isAuthenticated(res))
    //  this.authentication.redirectToLogin()
    //let data: any = res;
    //return of(data.Data);
    return of(model.data);
  }
}











