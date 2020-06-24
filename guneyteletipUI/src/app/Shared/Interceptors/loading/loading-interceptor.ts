import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpInterceptor,
  HttpEvent,
  HttpErrorResponse,
 } from '@angular/common/http';
import { finalize, retry, catchError } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';
import { NgxSpinnerService } from "ngx-spinner";

  
@Injectable()
export class LoadingInterceptor implements HttpInterceptor {
    private totalRequests = 0;
    constructor( private spinnerservice: NgxSpinnerService ) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        this.totalRequests++;
        //console.log('http intercepted');
        this.spinnerservice.show();

      return next.handle(req).pipe(
          
            finalize(() => {
                this.totalRequests--;
                if (this.totalRequests === 0) {
                    // console.log('http finished');
                    this.spinnerservice.hide();
                 }
            })
        );
    }
}

