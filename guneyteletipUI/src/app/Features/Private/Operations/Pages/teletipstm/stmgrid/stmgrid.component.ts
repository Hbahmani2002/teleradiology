import { Component, OnInit, Input } from '@angular/core';
import { Grid } from 'src/app/Shared/Models/UIControls/grid-control';
import { stmDataServices } from '../../../Services/stmDataServices';
import { GetorderStatusViewFilter } from '../../../Models/GetorderStatusViewFilter';

@Component({
  selector: 'app-stmgrid',
  templateUrl: './stmgrid.component.html',
  styleUrls: ['./stmgrid.component.css']
})
export class StmgridComponent implements OnInit {

  @Input() set filter(value: any) {
    if (value == null || value == undefined)
      return;
    console.log(value);
    this.gridStm.stmFilter = value;
    this.gridStm.onRefresh();
  }

  constructor(private stmService: stmDataServices) { }

  ngOnInit() {
  }
  stmFilter: stmFilter = new stmFilter();
  gridStm: StmComponent_Models.GridStm = new StmComponent_Models.GridStm(this.stmService, this.stmFilter);
}
export class stmFilter {
  basTar: any;
  bitTar: any;
  accessionNumberList: any[];
  hastaneIDList: any[];
  teletipStatusIDList: any[];
}
namespace StmComponent_Models {

  export class GridStm extends Grid.GridControl<any> {

    public direction: number = 0;
    selectAll: boolean = false;
    selectPage: boolean = false;

    constructor(private stmService: stmDataServices, public stmFilter: stmFilter) {
      super();
    }

    filter = new Grid.GridInputModel(new GetorderStatusViewFilter());
    getFilter() {

      this.filter.paging.pageNumber = this.model.paging.pageNumber;
      this.filter.paging.count = this.model.paging.count;
      this.filter.sorting = this.model.sorting;

      let item = this.filter.filter;
      var o = this.stmFilter;

      item.basTar = o.basTar;
      item.bitTar = o.bitTar;
      item.accessionNumberList = o.accessionNumberList;
      item.hastaneIDList = o.hastaneIDList;
      item.teletipStatusIDList = o.teletipStatusIDList;

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
      this.stmService.GetorderStatusList(item).subscribe(o => {
        this.data.list = o["list"];
        this.data.totalCount = o["totalCount"];
        console.log(this.data.list)
      })
    }
    gridSelect(event, type) {
      if (type == 'selectPage') {
        if (event.srcElement.checked) {
          this.selectAll = false;
        }
        console.log(event.srcElement.checked)
        this.onSelectAll(event);
      }
      else if (type == 'selectAll') {
        if (event.srcElement.checked) {
          this.selectPage = false;

          this.selectedItems.length = this.data.totalCount;
        }
        else {
          this.selectedItems.length = 0;
        }

      }
      else { }
    }
  }

}
