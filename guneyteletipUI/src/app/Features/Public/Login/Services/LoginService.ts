import { Injectable } from '@angular/core';
import { ApiService } from 'src/app/Shared/Services/Api/apiService';


@Injectable({
  providedIn: 'root'
})

export class LoginServices {
  constructor(private apiService: ApiService) { }

  login() {

  }

}
