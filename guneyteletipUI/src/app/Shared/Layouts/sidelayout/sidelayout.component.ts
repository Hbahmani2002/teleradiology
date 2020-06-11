import { Component, OnInit, ViewChild } from '@angular/core';
import { HeaderComponent } from './header/header.component';
@Component({
  selector: 'app-sidelayout',
  templateUrl: './sidelayout.component.html',
  styleUrls: ['./sidelayout.component.css']
})
export class SidelayoutComponent implements OnInit {

  public collapse: boolean = false;
  public isfirstCollapsed1: boolean = true;
  public isfirstCollapsed2: boolean = true;
  public isfirstCollapsed3: boolean = true;

  constructor() { }

  ngOnInit() {
    
  } 
  toggle() {
    if (this.collapse == true) {
      this.collapse = false;
    }
    else {
      this.collapse = true;
    }
  }
}
