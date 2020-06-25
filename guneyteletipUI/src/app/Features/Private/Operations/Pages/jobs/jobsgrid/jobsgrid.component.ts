import { Component, OnInit, Input } from '@angular/core';
import { Grid } from 'src/app/Shared/Models/UIControls/grid-control';
import { jobDataServices } from '../../../Services/jobDataServices';
import { infStudyFilter } from '../../../Models/infStudyFilter';
import { jobViewFilter } from '../../../Models/jobViewFilter';

@Component({
  selector: 'app-jobsgrid',
  templateUrl: './jobsgrid.component.html',
  styleUrls: ['./jobsgrid.component.css']
})
export class JobsgridComponent implements OnInit {
  @Input() set filter(value: any) {
    this.gridJobs.jobFilter = value;
    this.gridJobs.onRefresh();
  }
  constructor(private jobServices: jobDataServices) { }

  ngOnInit() {

  }

  jobFilter: jobFilter = new jobFilter();
  gridJobs: JobListComponent_Models.GridJob = new JobListComponent_Models.GridJob(this.jobServices, this.jobFilter);
}
export class jobFilter {
  dateRange = [];
  jobIdList;
  type;
}
namespace JobListComponent_Models {

  export class GridJob extends Grid.GridControl<any> {

    public direction: number = 0;
    selectAll: boolean = false;
    selectPage: boolean = false;

    constructor(private jobService: jobDataServices, public jobFilter: jobFilter) {
      super();
    }

    filter = new Grid.GridInputModel(new jobViewFilter());
    getFilter() {

      this.filter.paging.pageNumber = this.model.paging.pageNumber;
      this.filter.paging.count = this.model.paging.count;
      this.filter.sorting = this.model.sorting;

      let item = this.filter.filter;
      var o = this.jobFilter;

      item.jobidList = o.jobIdList;
      item.enumType = o.type;
      item.basTarih = o.dateRange[0];
      item.bitTarih = o.dateRange[1];

      return this.filter;
    };
    onSorting(colName) {
      if (this.direction == 0) {
        this.direction = 1;
      } else {
        this.direction = 0;
      }
      this.model.sorting.colName = colName;
      this.model.sorting.direction = this.direction;
      this.onRefresh();
    }
    onRefresh() {
      var item = this.getFilter()
      var filter = item.filter;
      console.log(item);
      this.jobService.getJobList(item).subscribe(o => {
        debugger;
        this.data.list = o["list"];
        this.data.totalCount = o["totalCount"];
        console.log(this.data.list)
      })
    }

  }

}
