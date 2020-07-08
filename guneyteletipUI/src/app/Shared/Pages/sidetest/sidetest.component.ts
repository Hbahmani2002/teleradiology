import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { LogoutService } from '../../Services/Util/logoutService';
import { ConfirmationdialogComponent } from '../../Modals/confirmationdialog/confirmationdialog.component';
import { OpenModal } from '../../Models/openModal';
import { BsModalService } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-sidetest',
  templateUrl: './sidetest.component.html',
  styleUrls: ['./sidetest.component.css']
})
export class SidetestComponent implements OnInit {
  public collapse: boolean = false;
  public collapse1: boolean = false;
  modal: OpenModal = new OpenModal(this.modalService, this.changeDetection);
  constructor(private logoutService: LogoutService, private modalService: BsModalService, private changeDetection: ChangeDetectorRef) { }

  ngOnInit() {
  }
  toggle() {
    if (this.collapse == true) {
      this.collapse = false;
    }
    else {
      this.collapse = true;
    }
  }
  toggleInSide() {
    if (!this.collapse) {
      this.toggle();
    }
  }
  logout() {
    const initialState = {
      modalTitle: "Uyarı",
      message: "Sistemden çıkış yapmak istediğinize emin misiniz?",
    };
    this.modal.openModal(ConfirmationdialogComponent, initialState).subscribe((result) => {
      if (result.reason == 'ok') {
        console.log("logout");
        this.logoutService.logout();
      }
    });
  }
}
