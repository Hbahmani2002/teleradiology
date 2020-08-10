import { Component, OnInit, Input, SimpleChanges, ChangeDetectorRef } from '@angular/core';
import { Grid } from 'src/app/Shared/Models/UIControls/grid-control';
import { kosDataServices } from '../../../Services/kosDataServices';
import { infStudyFilter } from '../../../Models/infStudyFilter';
import { ConfirmationdialogComponent } from 'src/app/Shared/Modals/confirmationdialog/confirmationdialog.component';
import { OpenModal } from 'src/app/Shared/Models/openModal';
import { BsModalService } from 'ngx-bootstrap/modal';
import { FileService } from 'src/app/Shared/Services/FileServices/fileService';


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
  constructor(private fileService: FileService, private kosService: kosDataServices, private modalService: BsModalService, private changeDetection: ChangeDetectorRef) { }

  ngOnInit() {
    console.log(this.gridKos.hasSelectedItem);
  }
  kosFilter: kosFilter = new kosFilter();
  gridKos: KosListComponent_Models.GridUser = new KosListComponent_Models.GridUser(this.fileService,this.kosService, this.kosFilter,this.modalService,this.changeDetection);
  
}
export class kosFilter {
  hastaneIDList;
  basTarih;
  bitTarih;
  modaliteList;
  EslesmeDurumuList;
  tcList;
  accessionNumberList;
}
namespace KosListComponent_Models {

  export class GridUser extends Grid.GridControl<any> {
      
    modal: OpenModal = new OpenModal(this.modalService, this.changeDetection);
    public direction: number = 0;
    selectAll: boolean = false;
    selectPage: boolean = false;

    constructor(private fileService: FileService, private kosService: kosDataServices, public kosFilter: kosFilter, private modalService: BsModalService, private changeDetection: ChangeDetectorRef) {
      super();
    }

    openConfirmationDialog(message, reproccessList?) {
      const initialState = {
        modalTitle: "Bilgilendirme",
        message: message,
        button1Text: "Tamam",
        dangerButtonEnable: false,
        reproccessList: reproccessList,
      };
      this.modal.openModal(ConfirmationdialogComponent, initialState).subscribe((result) => {
        console.log(result.reason);
        console.log(result.outputData);
      });
    }
    filter = new Grid.GridInputModel(new infStudyFilter());
    getFilter(type) {
      let list = [];
      this.filter.paging.pageNumber = this.model.paging.pageNumber;
      this.filter.paging.count = this.model.paging.count;
      this.filter.sorting = this.model.sorting;

      let item = this.filter.filter;
      var o = this.kosFilter;
      if (type != 2) {
        this.selectedItems.forEach(item => {
          list.push(item.id);
        });
      }

      item.StudyIDList = list;
      item.hastaneIDList = o.hastaneIDList;
      item.basTarih = o.basTarih;
      item.bitTarih = o.bitTarih;
      item.modaliteList = o.modaliteList;
      item.EslesmeDurumuList = o.EslesmeDurumuList;
      item.tcList = o.tcList;
      item.accessionNumberList = o.accessionNumberList;

      return this.filter;
    };

    onClickInstanceCreateKos() {
      this.kosService.instanceCreateKos(this.getFilter(1)).subscribe(o => {
        console.log(o);
        this.openConfirmationDialog("Başarılı : " + o.totalSuccess + " Başarısız : " + o.totalFail);
      });
    }

    onClickCreateKos() {
      if (this.selectAll) {
        let filter = this.getFilter(1).filter;
        filter = new infStudyFilter();
        this.kosService.createKosBg(filter).subscribe(o => {
          console.log(o);
          this.openConfirmationDialog("Arka plan iş takibi için ID'niz : " + o)
        });
      }
      else {
        this.kosService.createKos(this.getFilter(1)).subscribe(o => {
          console.log(o);
          this.openConfirmationDialog("Başarılı : " + o.totalSuccess + " Başarısız : " + o.totalFail);
        });
      }
    }


    onClickSendKos() {
      if (this.selectAll) {
        let filter = this.getFilter(1).filter;
        filter = new infStudyFilter();
        this.kosService.sendKosBg(filter).subscribe(o => {
          console.log(o);
          this.openConfirmationDialog("Arka plan iş takibi için ID'niz : " + o)
        });
      }
      else {
        this.kosService.sendKos(this.getFilter(1)).subscribe(o => {
          console.log(o);
          this.openConfirmationDialog("Başarılı : " + o.totalSuccess + " Başarısız : " + o.totalFail);
        });
      }
    }


    onClickDeleteKos() {
      if (this.selectAll) {
        let filter = this.getFilter(1).filter;
        filter = new infStudyFilter();
        this.kosService.deleteKosBg(filter).subscribe(o => {
          console.log(o);
          this.openConfirmationDialog("Arka plan iş takibi için ID'niz : " + o)
        });
      }
      else {
        this.kosService.deleteKos(this.getFilter(1)).subscribe(o => {
          console.log(o);
          this.openConfirmationDialog("Başarılı : " + o.totalSuccess + " Başarısız : " + o.totalFail);
        });
      }
    }
    onClickDeleteFromData() {
      console.log("onClickDeleteFromData");
      this.kosService.deleteFromData(this.getFilter(1)).subscribe(o => {
        console.log(o);
        this.openConfirmationDialog("İşlem tamamlandı.");
      });
    }

    onClickUpdateReadKos() {
      
      if (this.selectAll) {
        let filter = this.getFilter(1).filter;
        filter = new infStudyFilter();
        this.kosService.updateReadKosBg(filter).subscribe(o => {
          console.log(o);
          this.openConfirmationDialog("Arka plan iş takibi için ID'niz : " + o)
        });
      }
      else {
        this.kosService.updateReadKos(this.getFilter(1)).subscribe(o => {
          console.log(o);
          this.openConfirmationDialog("Başarılı : " + o.totalSuccess + " Başarısız : " + o.totalFail);
        });
      }
    }


    onClickReprocessKos() {
      if (this.selectAll) {
        let filter = this.getFilter(1).filter;
        filter = new infStudyFilter();
        this.kosService.reprocessKosBg(filter).subscribe(o => {
          console.log(o);
          this.openConfirmationDialog("Arka plan iş takibi için ID'niz : " + o)
        });
      }
      else {
        this.kosService.reprocessKos(this.getFilter(1)).subscribe(o => {
          debugger;
          console.log(o);
          this.openConfirmationDialog(undefined, o);
        });
      }
    }


    onClickExportExcel() {
      this.kosService.exportExcel(this.getFilter(1)).subscribe(o => {
        console.log(o);
        this.fileService.download(o);
      });
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
      var item = this.getFilter(2)
      var filter = item.filter;
      
      console.log(item);
      this.kosService.getKosList(item).subscribe(o => {
        this.data.list = o["list"];
        this.data.totalCount = o["totalCount"];
        console.log(this.data.list);
        filter.StudyIDList = [];
        this.selectedItems = [];
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
