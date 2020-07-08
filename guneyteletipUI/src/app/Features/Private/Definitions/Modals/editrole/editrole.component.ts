import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { OpenModal } from 'src/app/Shared/Models/openModal';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { roleDataServices } from '../../Services/roleDataServices';
import { saveRoleModel } from '../../Models/saveRoleModel';

@Component({
  selector: 'app-editrole',
  templateUrl: './editrole.component.html',
  styleUrls: ['./editrole.component.css']
})
export class EditroleComponent implements OnInit {

  public modalTitle: string;
  public roleID: string;
  idVisible: boolean;

  modal: OpenModal = new OpenModal(this.modalService, this.changeDetection);
  saveRolModel: saveRoleModel = new saveRoleModel();
  constructor(public bsModalRef: BsModalRef, private modalService: BsModalService, private changeDetection: ChangeDetectorRef, private roleService: roleDataServices) { }

  ngOnInit() {
    console.log(this.roleID);
    if (this.roleID == undefined) {
      this.idVisible = false;
    }
    else {
      this.idVisible = true;
      this.saveRolModel.id = this.roleID;
    }
  }
  getRoleByID() {
    
  }
  save() {
    console.log(this.saveRolModel);
    this.roleService.save(this.saveRolModel).subscribe(o => {
      console.log(o);
      this.modal.onClose('save');
    })
  }
  cancel(reason) {
    this.modal.onClose(reason);
  }
}
