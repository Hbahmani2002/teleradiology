import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { OpenModal } from 'src/app/Shared/Models/openModal';
import { userDataServices } from '../../Services/userDataServices';
import { userUIModel } from '../../Models/userUIModel';
import { UserSaveModel } from '../../Models/UserSaveModel';

@Component({
  selector: 'edituser',
  templateUrl: './edituser.component.html',
  styleUrls: ['./edituser.component.css']
})
export class EdituserComponent implements OnInit {

  public modalTitle: string;
  modal: OpenModal = new OpenModal(this.modalService, this.changeDetection);

  userModel: UserSaveModel = new UserSaveModel();

  public idDisabled = true;
  public userId;

  userUI: userUIModel = new userUIModel();
  constructor(public bsModalRef: BsModalRef, private modalService: BsModalService, private changeDetection: ChangeDetectorRef, private userService: userDataServices) { }

  ngOnInit() {
    if (this.userId == undefined) {
      this.idDisabled = false;
    }
    else {
      this.userUI.userID = this.userId;
      this.userService.getByID(this.userUI).subscribe(userData => {
        this.userModel = userData;
      });
    }
  }
  onSave() {
    
    if (this.userModel.recordState) {
      this.userModel.recordState = 1;
    }
    else {
      this.userModel.recordState = 0;
    }
    console.log(this.userModel);
    debugger;
    this.userService.save(this.userModel).subscribe(data => {
      console.log(data);
      this.modal.onClose("save");
    });
    //this.modal.onClose("save");
  }

   
 
}
