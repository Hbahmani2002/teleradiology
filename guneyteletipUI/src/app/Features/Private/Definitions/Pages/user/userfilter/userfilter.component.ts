import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-userfilter',
  templateUrl: './userfilter.component.html',
  styleUrls: ['./userfilter.component.css']
})
export class UserfilterComponent implements OnInit {

  @Output() username = new EventEmitter();

  isCollapsed = false;
  public userName = "";
  constructor() { }

  ngOnInit() {
  }
  onFilter() {
 
    this.username.emit(this.userName);
  }
  onClearFilter() {
    this.userName = "";
  }
}
