import { Component, OnInit } from '@angular/core';
import { defineLocale, trLocale } from 'ngx-bootstrap/chronos';
defineLocale('tr', trLocale);

@Component({
  selector: 'app-dashboardfilter',
  templateUrl: './dashboardfilter.component.html',
  styleUrls: ['./dashboardfilter.component.css']
})
export class DashboardfilterComponent implements OnInit {

  isCollapsed = false;

  constructor() { }

  ngOnInit() {
  }

}
