import { Component, OnInit, ChangeDetectorRef, Input } from '@angular/core';
import { EditroleComponent } from '../../../Modals/editrole/editrole.component';
import { OpenModal } from 'src/app/Shared/Models/openModal';
import { BsModalService } from 'ngx-bootstrap/modal';
import { ConfirmationdialogComponent } from 'src/app/Shared/Modals/confirmationdialog/confirmationdialog.component';
import { Grid } from 'src/app/Shared/Models/UIControls/grid-control';
import { roleDataServices } from '../../../Services/roleDataServices';
import { roleViewModel } from '../../../Models/RoleViewModel';
import { roleModel } from '../../../Models/roleModel';

@Component({
  selector: 'app-rolegrid',
  templateUrl: './rolegrid.component.html',
  styleUrls: ['./rolegrid.component.css']
})
export class RolegridComponent implements OnInit {

  /*@Input() set filterData(value: any) {
    if (value == null || value == undefined)
      return;
    this.roleFilter = value;
    this.gridRole.onRefresh();
  }*/


  modal: OpenModal = new OpenModal(this.modalService, this.changeDetection);

  constructor(private modalService: BsModalService, private changeDetection: ChangeDetectorRef, private roleService : roleDataServices) { }

  ngOnInit() {
    this.gridRole.onRefresh();
  }
  roleFilter: roleFilter = new roleFilter();
  gridRole: RoleListComponent_Models.GridRole = new RoleListComponent_Models.GridRole(this.roleService, this.roleFilter);
  rolModel: roleModel = new roleModel();
  openEditRoleModal(type: string) {
    if (type == 'ekle') {
      const initialState = {
        modalTitle: "Rol Ekle",
        roleId: undefined
      };
      this.modal.openModal(EditroleComponent, initialState).subscribe(reason => {
        if (reason.reason == 'save') {
          this.gridRole.onRefresh();
        }
      });
    }
    else if ('düzenle') {
      const initialState = {
        modalTitle: "Rol Düzenle",
        roleID: this.gridRole.clickedItem.roleID
      };
      this.modal.openModal(EditroleComponent, initialState).subscribe(reason => {
        if (reason.reason == 'save') {
          this.gridRole.onRefresh();
        }
      });
    }
  }
  openConfirmationDialog() {
    const initialState = {
      modalTitle: "UYARI!",
      message: "Rolü silmek istediğinize emin misiniz?"
    };
    this.modal.openModal(ConfirmationdialogComponent, initialState).subscribe(reason => {
      if (reason.reason == 'ok') {
        this.rolModel.rolID = this.gridRole.clickedItem.roleID;
        this.roleService.Delete(this.rolModel).subscribe(o => {
          console.log(o);
          this.gridRole.onRefresh();
        });
      }
    });
  }
}
export class roleFilter {
  id: any;
  roleName: any;
}
namespace RoleListComponent_Models {

  export class GridRole extends Grid.GridControl<any> {

    public direction: number = 0;

    constructor(private roleService: roleDataServices, private roleFilter: roleFilter) {
      super();
    }

    filter = new Grid.GridInputModel(new roleViewModel);//role filter gelecek
    getFilter() {

      this.filter.paging.pageNumber = this.model.paging.pageNumber;
      this.filter.paging.count = this.model.paging.count;
      this.filter.sorting = this.model.sorting;

      let item = this.filter.filter;
      var o = this.roleFilter;

      item.roleID = o.id;
      item.roleName = o.roleName;
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

      this.roleService.GetRoleList(item).subscribe(o => {
        this.data.list = o["list"];
        this.data.totalCount = o["totalCount"];
        console.log(this.data);
      })
    }
  }

}
