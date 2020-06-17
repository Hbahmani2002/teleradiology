import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-userfilter',
  templateUrl: './userfilter.component.html',
  styleUrls: ['./userfilter.component.css']
})
export class UserfilterComponent implements OnInit {

  isCollapsed = false;
  public userNameOutput;
  public userName;
  constructor() { }

  ngOnInit() {
  }
  onFilter() {
    this.userNameOutput = this.userName;
  }
}
