import { Injectable } from '@angular/core';
import { httpService } from 'src/app/Shared/Services/Util/httpService';
import { Observable, of, Subscription } from 'rxjs';
import { tokenService } from 'src/app/Shared/Services/Util/tokenService';
import { parameters } from 'src/app/Shared/Consts/parameters';
import { map, catchError, switchMap } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})

export class LoginServices {
  public serverAddress = parameters.serverAddress;
  public serviceAdress: string = parameters.loginServiceName;
  constructor(private httpService: httpService, private tokenService: tokenService ) { }

  login(userName: string, password: string): Observable<any> {

    let params = {
      userName: userName,
      password: password
    }
    //TODO error handling--Internet connection check
    return this.httpService.callPostService_Low(this.serverAddress + this.serviceAdress, params, undefined).pipe(
      switchMap(res => {
        debugger;
        if (res) {
          this.tokenService.saveToken(res.Data);
        }
        return of(res);
      }),
      catchError(err => {
          debugger;
          return of(err);
        })
        //result is success
    );
  }
}
