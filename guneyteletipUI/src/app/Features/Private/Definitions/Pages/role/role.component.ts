import { Component, OnInit, ViewChild } from '@angular/core';
import { RolefilterComponent } from './rolefilter/rolefilter.component';

@Component({
  selector: 'app-role',
  templateUrl: './role.component.html',
  styleUrls: ['./role.component.css']
})
export class RoleComponent implements OnInit {


  @ViewChild(RolefilterComponent, { static: false })
  public roleFilterComponent: RolefilterComponent;

  constructor() { }

  ngOnInit() {
  }

}
