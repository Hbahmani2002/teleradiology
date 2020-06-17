import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { EditroleComponent } from '../../../Modals/editrole/editrole.component';
import { OpenModal } from 'src/app/Shared/Models/openModal';
import { BsModalService } from 'ngx-bootstrap/modal';
import { ConfirmationdialogComponent } from 'src/app/Shared/Modals/confirmationdialog/confirmationdialog.component';
import { Grid } from 'src/app/Shared/Models/UIControls/grid-control';
import { roleDataServices } from '../../../Services/roleDataServices';

@Component({
  selector: 'app-rolegrid',
  templateUrl: './rolegrid.component.html',
  styleUrls: ['./rolegrid.component.css']
})
export class RolegridComponent implements OnInit {

  modal: OpenModal = new OpenModal(this.modalService, this.changeDetection);

  constructor(private modalService: BsModalService, private changeDetection: ChangeDetectorRef) { }

  ngOnInit() {
  }
  openEditRoleModal(type: string) {
    if (type == 'ekle') {
      const initialState = {
        modalTitle: "Role Ekle",
        roleId: undefined
      };
      this.modal.openModal(EditroleComponent, initialState);
    }
    else if ('düzenle') {
      const initialState = {
        modalTitle: "Role Düzenle",
        roleId: 1 //grin.clickedItem.roleıd
      };
      this.modal.openModal(EditroleComponent, initialState);
    }
  }
  openConfirmationDialog() {
    const initialState = {
      modalTitle: "UYARI!",
      message: "Rolü silmek istediğinize emin misiniz?"
    };
    this.modal.openModal(ConfirmationdialogComponent, initialState).subscribe((result) => {
      console.log(result.reason);
      if (result.reason == 'ok') {
        
      }
    });
  }
}
export class roleFilter {
  pk: any;
  emailAdress: any;
  name: any;
  password: any;
  surname: any;
  timeCreated: any;
  timeDelete: any;
  userFk: any;
  userName: any;
  userFkLastModfiead: any;
  recordType: any;
}
namespace RoleListComponent_Models {

  export class GridRole extends Grid.GridControl<any> {

    public direction: number = 0;

    constructor(private roleService: roleDataServices, private roleFilter: roleFilter) {
      super();
    }

   // filter = new Grid.GridInputModel(null);//role filter gelecek
    /*getFilter() {

      this.filter.paging.pageNumber = this.model.paging.pageNumber;
      this.filter.paging.count = this.model.paging.count;
      this.filter.sorting = this.model.sorting;

      let item = this.filter.filter;
      var o = this.userFilter;

      item.pk = o.pk;
      item.userName = o.userName;
      item.name = o.name;
      item.surname = o.surname;
      item.emailAdress = o.emailAdress;
      item.recordType = o.recordType;

      return this.filter;
    };*/
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
      /*var item = this.getFilter()
      var filter = item.filter;

      this.userService.getUserList(item).subscribe(o => {
        this.data.list = o["list"];
        this.data.totalCount = o["totalCount"];
      })*/
    }
  }

}
