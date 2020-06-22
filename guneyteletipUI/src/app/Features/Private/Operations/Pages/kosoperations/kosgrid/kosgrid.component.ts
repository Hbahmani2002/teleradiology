import { Component, OnInit, Input, SimpleChanges } from '@angular/core';
import { Grid } from 'src/app/Shared/Models/UIControls/grid-control';
import { kosDataServices } from '../../../Services/kosDataServices';
import { infStudyFilter } from '../../../Models/infStudyFilter';


@Component({
  selector: 'app-kosgrid',
  templateUrl: './kosgrid.component.html',
  styleUrls: ['./kosgrid.component.css']
})
export class KosgridComponent implements OnInit {
  
  @Input() set filter(value: any) {
    if (value == null || value == undefined)
      return;
    this.gridKos.kosFilter = value;
    this.gridKos.onRefresh();
  }
  constructor(private kosService: kosDataServices) { }

  ngOnInit() {
  
  }
  kosFilter: kosFilter = new kosFilter();
  gridKos: KosListComponent_Models.GridUser = new KosListComponent_Models.GridUser(this.kosService, this.kosFilter);

}
export class kosFilter {
  hastaneIDList;
  basTarih;
  bitTarih;
  modalite;
  eslesmeDurumu;
  tcList;
  accessionNumberList;
}
namespace KosListComponent_Models {

  export class GridUser extends Grid.GridControl<any> {

    public direction: number = 0;
    selectAll: boolean = false;
    selectPage: boolean = false;

    constructor(private kosService: kosDataServices, public kosFilter: kosFilter) {
      super();
    }

    filter = new Grid.GridInputModel(new infStudyFilter());
    getFilter() {

      this.filter.paging.pageNumber = this.model.paging.pageNumber;
      this.filter.paging.count = this.model.paging.count;
      this.filter.sorting = this.model.sorting;

      let item = this.filter.filter;
      var o = this.kosFilter;

      item.hastaneIDList = o.hastaneIDList;
      item.basTarih = o.bitTarih;
      item.modalite = o.modalite;
      item.eslesmeDurumu = o.eslesmeDurumu;
      item.tcList = o.tcList;
      item.accessionNumberList = o.accessionNumberList;

      return this.filter;
    };

    onClickCreateKos() {
      this.kosService.createKos(this.getFilter()).subscribe(o => {
        console.log(o);
      });
    }
    onClickSendKos() {
      this.kosService.sendKos(this.getFilter()).subscribe(o => {
        console.log(o);
      });;
    }
    onClickDeleteKos() {
      this.kosService.deleteKos(this.getFilter()).subscribe(o => {
        console.log(o);
      });;
    }
    onClickUpdateReadKos() {
      this.kosService.updateReadKos(this.getFilter()).subscribe(o => {
        console.log(o);
      });;
    }
    onClickReprocessKos() {
      this.kosService.reprocessKos(this.getFilter()).subscribe(o => {
        console.log(o);
      });;
    }
    onClickExportExcel() {
      this.kosService.exportExcel(this.getFilter()).subscribe(o => {
        console.log(o);
      });;
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
      this.kosService.getKosList(item).subscribe(o => {
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
        }
        this.onSelectAllItems();
      }
      else { }
    }
  }

}
