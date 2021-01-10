import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { OpenModal } from '../../Models/openModal';

@Component({
  selector: 'app-inputmodal',
  templateUrl: './inputmodal.component.html',
  styleUrls: ['./inputmodal.component.css']
})
export class InputmodalComponent implements OnInit {

    public output = undefined;// modal'ın açıldığı sayfada modal kapandıktan sonra aktarılacak veri 
    public inputValue;
    modal: OpenModal = new OpenModal(this.modalService, this.changeDetection);
    constructor(public bsModalRef: BsModalRef, private modalService: BsModalService, private changeDetection: ChangeDetectorRef) { }
    ngOnInit() {}
    onConfirm() {
        this.output = this.inputValue;
        this.modal.onClose("ok");
    }
    onCancel() {
        this.output = false;
        this.modal.onClose("cancel");
    }
}
