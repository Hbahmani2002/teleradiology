import { ChangeDetectorRef,Component, OnInit } from '@angular/core';
import { EdituserComponent } from '../../../Modals/edituser/edituser.component';
import { BsModalService } from 'ngx-bootstrap/modal';
import { ConfirmationdialogComponent } from 'src/app/Shared/Modals/confirmationdialog/confirmationdialog.component';
import { OpenModal } from 'src/app/Shared/Models/openModal';
import { combineLatest, Subscription } from 'rxjs';
@Component({
  selector: 'app-usergrid',
  templateUrl: './usergrid.component.html',
  styleUrls: ['./usergrid.component.css']
})
export class UsergridComponent implements OnInit {

  constructor(private modalService: BsModalService, private changeDetection: ChangeDetectorRef) { }

  modal: OpenModal = new OpenModal(this.modalService,this.changeDetection);

  ngOnInit() { }

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

    console.log(this.modal.messages);
  }
  openConfirmationDialog() {
    const initialState = {
      modalTitle: "UYARI!",
      message: "Kullanıcıyı silmek istediğinize emin misiniz?"
    };
    this.modal.openModal(ConfirmationdialogComponent, initialState);
  }
}
