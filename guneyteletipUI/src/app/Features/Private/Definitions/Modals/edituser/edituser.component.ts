import { Component, OnInit, ChangeDetectorRef, EventEmitter } from '@angular/core';
import { ModalDirective, BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { OpenModal } from 'src/app/Shared/Models/openModal';
import { userViewModel } from '../../Models/UserViewModel';
import { userDataServices } from '../../Services/userDataServices';
import { userUIModel } from '../../Models/userUIModel';

@Component({
  selector: 'edituser',
  templateUrl: './edituser.component.html',
  styleUrls: ['./edituser.component.css']
})
export class EdituserComponent implements OnInit {

  public modalTitle: string;
  modal: OpenModal = new OpenModal(this.modalService, this.changeDetection);
  userViewModel: userViewModel = new userViewModel();
  public idDisabled = true;
  public userId;
  userUIModel: userUIModel = new userUIModel();
  constructor(public bsModalRef: BsModalRef, private modalService: BsModalService, private changeDetection: ChangeDetectorRef, private userService: userDataServices) { }

  ngOnInit() {
    if (this.userId == undefined) {
      this.idDisabled = false;
    }
    else {
      this.userUIModel.userID = this.userId;
      this.userService.getByID(this.userUIModel).subscribe(userData => {
        this.userViewModel = userData;
      });
    }
  }
  onSave() {
    this.modal.onClose("save");
  }

   
 
}
