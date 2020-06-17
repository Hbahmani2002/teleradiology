import { ChangeDetectorRef,Component, OnInit } from '@angular/core';
import { EdituserComponent } from '../../../Modals/edituser/edituser.component';
import { BsModalService } from 'ngx-bootstrap/modal';
import { ConfirmationdialogComponent } from 'src/app/Shared/Modals/confirmationdialog/confirmationdialog.component';
import { OpenModal } from 'src/app/Shared/Models/openModal';
import { of } from 'rxjs';
import { switchMap, catchError  } from 'rxjs/operators';
import { Grid } from 'src/app/Shared/Models/UIControls/grid-control';
import { userDataServices } from '../../../Services/userDataServices';
import { UserViewFilter } from '../../../Models/UserViewFilter';
@Component({
  selector: 'app-usergrid',
  templateUrl: './usergrid.component.html',
  styleUrls: ['./usergrid.component.css']
})
export class UsergridComponent implements OnInit {

  modal: OpenModal = new OpenModal(this.modalService, this.changeDetection);

  constructor(private modalService: BsModalService, private changeDetection: ChangeDetectorRef,private userService: userDataServices) { }

  ngOnInit() {
    this.gridUser.onRefresh();
  }

  userFilter: userFilter = new userFilter();
  gridUser: UserListComponent_Models.GridUser = new UserListComponent_Models.GridUser(this.userService, this.userFilter);

  openEditUserModal(type: string) {
    if (type == 'ekle') {
      const initialState = {
        modalTitle: "Kullanıcı Ekle"
      };
      this.modal.openModal(EdituserComponent, initialState);
      
    }
    else if ('düzenle') {
      const initialState = {
        modalTitle: "Kullanıcı Düzenle"
      };
      this.modal.openModal(EdituserComponent, initialState);
    }
  }
  openConfirmationDialog() {
    const initialState = {
      modalTitle: "UYARI!",
      message: "Kullanıcıyı silmek istediğinize emin misiniz?"
    };
    this.modal.openModal(ConfirmationdialogComponent, initialState);
  }
}
export class userFilter {
  pk: any;
  emailAdress: any;
  name: any;
  surname: any;
  userName: any;
  recordType: any;
}
namespace UserListComponent_Models {

  export class GridUser extends Grid.GridControl<any> {

    public direction: number = 0;

    constructor(private userService: userDataServices, private userFilter: userFilter) {
      super();
    }

    filter = new Grid.GridInputModel(new UserViewFilter());
    getFilter() {

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
        debugger;
        this.data = o;
      })
    }
  }

}
