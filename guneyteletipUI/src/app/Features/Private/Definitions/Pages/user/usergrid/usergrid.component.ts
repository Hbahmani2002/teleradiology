import { ChangeDetectorRef,Component, OnInit, Input } from '@angular/core';
import { EdituserComponent } from '../../../Modals/edituser/edituser.component';
import { BsModalService } from 'ngx-bootstrap/modal';
import { ConfirmationdialogComponent } from 'src/app/Shared/Modals/confirmationdialog/confirmationdialog.component';
import { OpenModal } from 'src/app/Shared/Models/openModal';
import { Grid } from 'src/app/Shared/Models/UIControls/grid-control';
import { userDataServices } from '../../../Services/userDataServices';
import { userViewFilter } from '../../../Models/UserViewFilter';
import { userUIModel } from '../../../Models/userUIModel';
import { UserSaveModel } from '../../../Models/userSaveModel';

@Component({
  selector: 'app-usergrid',
  templateUrl: './usergrid.component.html',
  styleUrls: ['./usergrid.component.css']
})
export class UsergridComponent implements OnInit {

  @Input() set filterValue(value: any) {
    if (value == null || value == undefined)
      return;
    debugger;
    this.gridUser.userFilter.UserName = value;
    this.gridUser.onRefresh();
  }

  modal: OpenModal = new OpenModal(this.modalService, this.changeDetection);
  userUIModel: userUIModel = new userUIModel();
  constructor(private modalService: BsModalService, private changeDetection: ChangeDetectorRef,private userService: userDataServices) { }

  ngOnInit() {
    this.gridUser.onRefresh();
  }

  userFilter: userFilter = new userFilter();
  gridUser: UserListComponent_Models.GridUser = new UserListComponent_Models.GridUser(this.userService, this.userFilter);
  selectedUserModel: UserSaveModel = new UserSaveModel();

  openEditUserModal(type: string) {

    if (type == 'ekle') {
      const initialState = {
        modalTitle: "Kullanıcı Ekle",
        userId: undefined,
      };
      this.modal.openModal(EdituserComponent, initialState).subscribe((data) => {
        console.log(data.reason);
        if (data.reason == 'save') {
          this.gridUser.onRefresh();
        }
        
      });
    }
    else if ('düzenle') {
      const initialState = {
        modalTitle: "Kullanıcı Düzenle",
        userId: this.gridUser.clickedItem.id
      };
      this.modal.openModal(EdituserComponent, initialState).subscribe((data) => {
        console.log(data.reason);
        if (data.reason == 'save') {
          this.gridUser.onRefresh();
        }
      });
    }
  }
  openConfirmationDialog() {
    const initialState = {
      modalTitle: "UYARI!",
      message: "Kullanıcıyı silmek istediğinize emin misiniz?"
    };
    this.modal.openModal(ConfirmationdialogComponent, initialState).subscribe((result) => {

      console.log(result.reason);
      console.log(result.outputData);
      if (result.reason == 'ok') {
        this.userUIModel.userID = this.gridUser.clickedItem.pk;
        this.userService.delete(this.userUIModel).subscribe(o => {
          console.log(o);
          this.gridUser.onRefresh();
        });
      }
    });
  }
}
export class userFilter {
  ID: any;
  EmailAdress: any;
  Name: any;
  Surname: any;
  RolName: any;
  RolID: any;
  UserName: any;
}
namespace UserListComponent_Models {

  export class GridUser extends Grid.GridControl<any> {

    public direction: number = 0;

    constructor(private userService: userDataServices, public userFilter: userFilter) {
      super();
    }

    filter = new Grid.GridInputModel(new userViewFilter());
    getFilter() {

      this.filter.paging.pageNumber = this.model.paging.pageNumber;
      this.filter.paging.count = this.model.paging.count;
      this.filter.sorting = this.model.sorting;

      let item = this.filter.filter;
      var o = this.userFilter;

      item.UserName = o.UserName;
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

      this.userService.getUserList(item).subscribe(o => {
       
        this.data.list = o["list"];
        this.data.totalCount = o["totalCount"];
        console.log(this.data.list)
      })
    }
  }

}
