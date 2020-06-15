import { Component, OnInit } from '@angular/core';
import { LoginServices } from '../../Services/LoginService';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public userName;
  public password;
  constructor(private loginService: LoginServices, private routing: Router) { }
  
  ngOnInit() {
  }
  login() {
    debugger;
    this.loginService.login(this.userName, this.password).subscribe(o => {
      if (o != 1) {
        //
        return;
      }
      console.log("loginned");
      this.routing.navigate(["operations/kos"]);
    });
  }
}
