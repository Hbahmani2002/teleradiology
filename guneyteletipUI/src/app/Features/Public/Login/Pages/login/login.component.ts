import { Component, OnInit } from '@angular/core';
import { LoginServices, LoginEnumResult } from '../../Services/LoginService';
import { Router } from '@angular/router';
import { debug } from 'util';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public userName;
  public password;
  alertMessage;
  constructor(private loginService: LoginServices, private routing: Router) { }
  
  ngOnInit() {
   
  }
  login() {
 
    this.loginService.login(this.userName, this.password).subscribe(o => {
      
      if (o != LoginEnumResult.ok) {
        this.alertMessage = o.error.Message
        return;
      }
      console.log("loginned");
      localStorage.setItem('file','');
      this.routing.navigate(["operations/kos"]);
    });
  }
}
