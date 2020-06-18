import { Component, OnInit } from '@angular/core';
import { Grid } from 'src/app/Shared/Models/UIControls/grid-control';
import { kosDataServices } from '../../../Services/kosDataServices';
import { infStudyFilter } from '../../../Models/infStudyFilter';

@Component({
  selector: 'app-kosgrid',
  templateUrl: './kosgrid.component.html',
  styleUrls: ['./kosgrid.component.css']
})
export class KosgridComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
export class kosFilter {
  hastaneList: any[];
  basTarih: any;
  bitTarih: any;
  modalite: any;
  eslesmeDurumu: any;
  tcList: any[];
  accessionNumberList: any[];
}
namespace KosListComponent_Models {

  export class GridUser extends Grid.GridControl<any> {

    public direction: number = 0;

    constructor(private kosService: kosDataServices, private kosFilter: kosFilter) {
      super();
    }

    filter = new Grid.GridInputModel(new infStudyFilter());
    getFilter() {

      this.filter.paging.pageNumber = this.model.paging.pageNumber;
      this.filter.paging.count = this.model.paging.count;
      this.filter.sorting = this.model.sorting;

      let item = this.filter.filter;
      var o = this.kosFilter;

      /*item.pk = o.pk;
      item.userName = o.userName;
      item.name = o.name;
      item.surname = o.surname;
      item.emailAdress = o.emailAdress;
      item.recordType = o.recordType;*/

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

      this.kosService.getKosList(item).subscribe(o => {
        this.data.list = o["list"];
        this.data.totalCount = o["totalCount"];
      })
    }
  }

}
