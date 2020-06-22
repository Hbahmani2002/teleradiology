import { Component, OnInit } from '@angular/core';
import { jobFilter } from './jobsgrid/jobsgrid.component';

@Component({
  selector: 'app-jobs',
  templateUrl: './jobs.component.html',
  styleUrls: ['./jobs.component.css']
})
export class JobsComponent implements OnInit {

  constructor() { }
  filterData: jobFilter = new jobFilter();
  ngOnInit() {
  }
  filter(filter) {
    this.filterData = filter;
  }
}
