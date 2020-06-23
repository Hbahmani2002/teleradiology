import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { jobFilter } from '../jobsgrid/jobsgrid.component';

@Component({
  selector: 'app-jobsfilter',
  templateUrl: './jobsfilter.component.html',
  styleUrls: ['./jobsfilter.component.css']
})
export class JobsfilterComponent implements OnInit {

  @Output() filterChanged = new EventEmitter<jobFilter>();
  filterData: jobFilter = new jobFilter();

  constructor() { }
  
  ngOnInit() {
  }
  onFilter() {
    let filter = new jobFilter();
    filter.dateRange = this.filterData.dateRange;
    filter.jobId = this.filterData.jobId;
    filter.type = this.filterData.type;

    this.filterChanged.emit(filter);
    
  }
}
