import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-rolefilter',
  templateUrl: './rolefilter.component.html',
  styleUrls: ['./rolefilter.component.css']
})
export class RolefilterComponent implements OnInit {

  constructor() { }
  roleName;
  roleNameOutput;
  ngOnInit() {
  }
  onFiler() {
    this.roleNameOutput = this.roleName;
  }
}
