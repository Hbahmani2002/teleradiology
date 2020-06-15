import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
//import { CookieService } from 'ngx-cookie-service';
//import { ToastrService } from 'ngx-toastr';
import { map, catchError, switchMap } from 'rxjs/operators';
import { of, Observable } from 'rxjs';
//import { FileService } from './file.service';
//import { environment } from './../shared/consts/environment';
//import { NotificationToastService } from '../Shared/services/notification-toast.service';
import { Router } from '@angular/router';
import { parameters } from '../../Consts/parameters';
//import { cookieService } from '../shared/services/cookieService';
//import { authenticationService } from '../shared/services/authenticationService';


@Injectable({
  providedIn: 'root'
})
export class httpService {

  constructor(
    private http: HttpClient
    /*private toastr: ToastrService,
    private cookieService: cookieService,
    private routing: Router,
    private notificationToast: NotificationToastService,
    public fileOperation: FileService,
    public authentication: authenticationService*/
  ) {

  }


  public callPostService_Low(url: string, params: any, httpOptions: any = undefined): Observable<any> {
    /*
     ##validation
    headeroptions
    */
    return this.http.post(url, params, httpOptions);

  }
  public callPostService_Middle(url: string, params: any, token: any): Observable<any> {
   
   // var url = this.serverAddress + serviceName;
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'accept': 'application/json',
        "Authorization": 'Bearer ' + token
      })
    };
    debugger;
    return this.callPostService_Low(url, params, httpOptions);
  }



  
}
