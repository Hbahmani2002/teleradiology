import { Component, OnInit, Input } from '@angular/core';
import { kosDataServices } from '../../../../Services/kosDataServices';
import { Grid } from 'src/app/Shared/Models/UIControls/grid-control';
import { kosHistoryModel } from '../../../../Models/KosHistoryModel';

@Component({
  selector: 'app-kosdetailgrid',
  templateUrl: './kosdetailgrid.component.html',
  styleUrls: ['./kosdetailgrid.component.css']
})
export class KosdetailgridComponent implements OnInit {

  @Input() set kosId(value: any) {
    if (value == null || value == undefined)
      return;
    console.log(value);
    this.gridKosDetail.detailFilter.id = value;
    this.gridKosDetail.onRefresh();
  }
  
  constructor(private kosService: kosDataServices) { }

  ngOnInit() {
    //this.gridKosDetail.onRefresh();
  }
  detailFilter: kosDetailFilter = new kosDetailFilter();
  gridKosDetail: KosDetailComponent_Models.GridKosDetail = new KosDetailComponent_Models.GridKosDetail(this.kosService, this.detailFilter);
}
export class kosDetailFilter {
  id: any;
  kosStudyID: any;
  result: any;
  enumType: any;
  timeCreated: any;
  timeModified: any;
  userIDCreated: any;
  userIDModified: any;
}
namespace KosDetailComponent_Models {

  export class GridKosDetail extends Grid.GridControl<any> {

    public direction: number = 0;

    constructor(private kosService: kosDataServices, public detailFilter: kosDetailFilter) {
      super();
    }

    filter = new Grid.GridInputModel(new kosHistoryModel());
    getFilter() {

      this.filter.paging.pageNumber = this.model.paging.pageNumber;
      this.filter.paging.count = this.model.paging.count;
      this.filter.sorting = this.model.sorting;

      let item = this.filter.filter;
      var o = this.detailFilter;

      item.enumType = o.enumType;
      item.id = o.id;
      item.kosStudyID = o.kosStudyID;
      item.result = o.result;
      item.timeCreated = o.timeCreated;
      item.timeModified = o.timeModified;
      item.userIDCreated = o.userIDCreated;
      item.userIDModified = o.userIDModified;

      return this.filter;
    }
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

      this.kosService.GetKosHistoryByStudyID(item).subscribe(o => {
   
        this.data.list = o["list"];
        this.data.totalCount = o["totalCount"];
        console.log(this.data.list)
      })
    }
  }

}
