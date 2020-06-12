import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-kosstatistic',
  templateUrl: './kosstatistic.component.html',
  styleUrls: ['./kosstatistic.component.css']
})
export class KosstatisticComponent implements OnInit {

  public isCollapsed: boolean = true;
  public isCollapsed1: boolean = true;

  constructor() { }

  ngOnInit() {
  }

}
