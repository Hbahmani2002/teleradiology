import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { EditroleComponent } from '../../../Modals/editrole/editrole.component';
import { OpenModal } from 'src/app/Shared/Models/openModal';
import { BsModalService } from 'ngx-bootstrap/modal';
import { ConfirmationdialogComponent } from 'src/app/Shared/Modals/confirmationdialog/confirmationdialog.component';

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
        modalTitle: "Role Ekle"
      };
      this.modal.openModal(EditroleComponent, initialState);
    }
    else if ('düzenle') {
      const initialState = {
        modalTitle: "Role Düzenle"
      };
      this.modal.openModal(EditroleComponent, initialState);
    }

    
  }
  openConfirmationDialog() {
    const initialState = {
      modalTitle: "UYARI!",
      message: "Rolü silmek istediğinize emin misiniz?"
    };
    this.modal.openModal(ConfirmationdialogComponent, initialState);
  }

}
//api_gt_test.protek.saglik.com
