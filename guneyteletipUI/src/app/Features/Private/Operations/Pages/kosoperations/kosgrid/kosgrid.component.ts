import { Component, OnInit, Input, SimpleChanges, ChangeDetectorRef } from '@angular/core';
import { Grid } from 'src/app/Shared/Models/UIControls/grid-control';
import { kosDataServices } from '../../../Services/kosDataServices';
import { infStudyFilter } from '../../../Models/infStudyFilter';
import { ConfirmationdialogComponent } from 'src/app/Shared/Modals/confirmationdialog/confirmationdialog.component';
import { OpenModal } from 'src/app/Shared/Models/openModal';
import { BsModalService } from 'ngx-bootstrap/modal';


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
  constructor(private kosService: kosDataServices, private modalService: BsModalService, private changeDetection: ChangeDetectorRef) { }

  ngOnInit() {
  
  }
  kosFilter: kosFilter = new kosFilter();
  gridKos: KosListComponent_Models.GridUser = new KosListComponent_Models.GridUser(this.kosService, this.kosFilter,this.modalService,this.changeDetection);

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

    modal: OpenModal = new OpenModal(this.modalService, this.changeDetection);
    public direction: number = 0;
    selectAll: boolean = false;
    selectPage: boolean = false;

    constructor(private kosService: kosDataServices, public kosFilter: kosFilter, private modalService: BsModalService, private changeDetection: ChangeDetectorRef) {
      super();
    }
    openConfirmationDialog(message) {
      const initialState = {
        modalTitle: "Bilgilendirme",
        message: message
      };
      this.modal.openModal(ConfirmationdialogComponent, initialState).subscribe((result) => {
        console.log(result.reason);
        console.log(result.outputData);
      });
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
      if (this.selectAll) {
        let filter = this.getFilter().filter;
        filter = new infStudyFilter();
        this.kosService.createKosBg(filter).subscribe(o => {
          console.log(o);
          this.openConfirmationDialog("Arka plan iş takibi için ID'niz : " + o)
        });
      }
      else {
        this.kosService.createKos(this.getFilter()).subscribe(o => {
          console.log(o);
          this.openConfirmationDialog("Arka plan iş takibi için ID'niz : " + o)
        });
      }
    }


    onClickSendKos() {
      if (this.selectAll) {
        let filter = this.getFilter().filter;
        filter = new infStudyFilter();
        this.kosService.sendKosBg(filter).subscribe(o => {
          console.log(o);
          this.openConfirmationDialog("Arka plan iş takibi için ID'niz : " + o)
        });
      }
      else {
        this.kosService.sendKos(this.getFilter()).subscribe(o => {
          console.log(o);
          this.openConfirmationDialog("Arka plan iş takibi için ID'niz : " + o)
        });
      }
    }


    onClickDeleteKos() {
      if (this.selectAll) {
        let filter = this.getFilter().filter;
        filter = new infStudyFilter();
        this.kosService.deleteKosBg(filter).subscribe(o => {
          console.log(o);
          this.openConfirmationDialog("Arka plan iş takibi için ID'niz : " + o)
        });
      }
      else {
        this.kosService.deleteKos(this.getFilter()).subscribe(o => {
          console.log(o);
          this.openConfirmationDialog("Arka plan iş takibi için ID'niz : " + o)
        });
      }
    }


    onClickUpdateReadKos() {
      if (this.selectAll) {
        let filter = this.getFilter().filter;
        filter = new infStudyFilter();
        this.kosService.updateReadKosBg(filter).subscribe(o => {
          console.log(o);
          this.openConfirmationDialog("Arka plan iş takibi için ID'niz : " + o)
        });
      }
      else {
        this.kosService.updateReadKos(this.getFilter()).subscribe(o => {
          console.log(o);
          this.openConfirmationDialog("Arka plan iş takibi için ID'niz : " + o)
        });
      }
    }


    onClickReprocessKos() {
      if (this.selectAll) {
        let filter = this.getFilter().filter;
        filter = new infStudyFilter();
        this.kosService.reprocessKosBg(filter).subscribe(o => {
          console.log(o);
          this.openConfirmationDialog("Arka plan iş takibi için ID'niz : " + o)
        });
      }
      else {
        this.kosService.reprocessKos(this.getFilter()).subscribe(o => {
          console.log(o);
          this.openConfirmationDialog("Arka plan iş takibi için ID'niz : " + o)
        });
      }
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
