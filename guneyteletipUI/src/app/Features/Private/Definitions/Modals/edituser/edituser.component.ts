import { Component, OnInit, ChangeDetectorRef, EventEmitter } from '@angular/core';
import { ModalDirective, BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { OpenModal } from 'src/app/Shared/Models/openModal';
import { UserView } from '../../Models/UserView';

@Component({
  selector: 'edituser',
  templateUrl: './edituser.component.html',
  styleUrls: ['./edituser.component.css']
})
export class EdituserComponent implements OnInit {

  public modalTitle: string;
  modal: OpenModal = new OpenModal(this.modalService, this.changeDetection);
  userViewModel: UserView = new UserView();

  constructor(public bsModalRef: BsModalRef, private modalService: BsModalService, private changeDetection: ChangeDetectorRef) { }

  ngOnInit() {
    
  }
  onSave() {
    this.modal.onClose("save", this.userViewModel);
  }

   
 
}
