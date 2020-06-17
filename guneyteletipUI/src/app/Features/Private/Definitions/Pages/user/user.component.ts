import { Component, OnInit, ViewChild } from '@angular/core';
import { UserfilterComponent } from './userfilter/userfilter.component';
import { UsergridComponent } from './usergrid/usergrid.component';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  @ViewChild(UserfilterComponent, { static: false })
  public userFilterComponent: UserfilterComponent;

  @ViewChild(UsergridComponent, { static: false })
  public userGridComponent: UsergridComponent;

  constructor() { }

  ngOnInit() {
  }

}
