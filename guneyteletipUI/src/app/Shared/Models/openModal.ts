import { ChangeDetectorRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { combineLatest, Subscription } from 'rxjs';
export class OpenModal {
  modalRef: BsModalRef;
  subscriptions: Subscription[] = [];
  messages: string[] = [];
  constructor(private modalService: BsModalService, private changeDetection: ChangeDetectorRef) {}
  openModal(template, initialState) {
    this.messages = [];
    const _combine = combineLatest(
      this.modalService.onShow,
      this.modalService.onShown,
      this.modalService.onHide,
      this.modalService.onHidden
    ).subscribe(() => this.changeDetection.markForCheck());
    this.subscriptions.push(
      this.modalService.onHidden.subscribe((reason: string) => {
        const _reason = reason ? `, dismissed by ${reason}` : '';
        this.messages.push(`onHide event has been fired${_reason}`);
        console.log(initialState.modalTitle + `${_reason}`)
        this.unsubscribe();
      })
    );
    this.subscriptions.push(_combine);
    this.modalRef = this.modalService.show(template, { initialState: initialState });
    return this.subscriptions[0];
  }
  unsubscribe() {
    this.subscriptions.forEach((subscription: Subscription) => {
      subscription.unsubscribe();
    });
    this.subscriptions = [];
  }
  onClose(reason: string,data:any) {
    this.modalService.setDismissReason(reason);
    this.modalService.hide(1);
  }
}
