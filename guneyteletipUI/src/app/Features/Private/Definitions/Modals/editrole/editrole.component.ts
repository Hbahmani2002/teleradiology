import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { OpenModal } from 'src/app/Shared/Models/openModal';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-editrole',
  templateUrl: './editrole.component.html',
  styleUrls: ['./editrole.component.css']
})
export class EditroleComponent implements OnInit {

  public modalTitle: string;

  modal: OpenModal = new OpenModal(this.modalService, this.changeDetection);

  constructor(public bsModalRef: BsModalRef, private modalService: BsModalService, private changeDetection: ChangeDetectorRef) { }

  ngOnInit() {
  }

}
