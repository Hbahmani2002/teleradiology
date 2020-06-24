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
    let jobIdList = [];
    filter.dateRange = this.filterData.dateRange;
    if (this.filterData.jobIdList == "" || this.filterData.jobIdList == undefined) {

    }
    else {
      this.filterData.jobIdList.split(" ").forEach(item => {
        if (item != "") {
          jobIdList.push(item);
        }
      });
    }
    filter.jobIdList = jobIdList;
    filter.type = this.filterData.type;

    this.filterChanged.emit(filter);
    
  }
}
