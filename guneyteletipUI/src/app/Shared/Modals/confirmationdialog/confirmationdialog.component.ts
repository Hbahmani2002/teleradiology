import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { OpenModal } from '../../Models/openModal';

@Component({
  selector: 'app-confirmationdialog',
  templateUrl: './confirmationdialog.component.html',
  styleUrls: ['./confirmationdialog.component.css']
})
export class ConfirmationdialogComponent implements OnInit {
  
  public modalTitle: string;
  public message: string;

  public output = undefined;// modal'ın açıldığı sayfada modal kapandıktan sonra alınacak veri

  modal: OpenModal = new OpenModal(this.modalService, this.changeDetection);
  constructor(public bsModalRef: BsModalRef, private modalService: BsModalService, private changeDetection: ChangeDetectorRef) { }

  ngOnInit() {
  }
  onConfirm() {
    this.output = 'confirm';
    this.modal.onClose("ok");
  }
  onCancel() {
    this.output = 'cancel';
    this.modal.onClose("cancel");
  }
}
