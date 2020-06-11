import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashboard-statistic',
  templateUrl: './dashboard-statistic.component.html',
  styleUrls: ['./dashboard-statistic.component.css']
})
export class DashboardStatisticComponent implements OnInit {

  public isCollapsed: boolean = true;
  public isCollapsed1: boolean = true;

  constructor() { }

  ngOnInit() {
  }

}
