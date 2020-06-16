import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class toastoastService {

  constructor(private toastr: ToastrService) {

  }
  public success(message: string) {
    this.toastr.success(message);
  }
  public error(message: string) {
    this.toastr.error(message);
  }
  
}
