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
  modal: OpenModal = new OpenModal(this.modalService, this.changeDetection);
  constructor(public bsModalRef: BsModalRef, private modalService: BsModalService, private changeDetection: ChangeDetectorRef) { }

  ngOnInit() {
  }
}
