import { ChangeDetectorRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Subscription, Observable } from 'rxjs';
import { modalOutput } from './modalOutput';

export class OpenModal {

  bsModalRef: BsModalRef;
  subscriptions: Subscription[] = [];
  messages: string[] = [];
  data: any;

  constructor(private modalService: BsModalService, private changeDetection: ChangeDetectorRef) {}

  openModal(template, initialState): Observable<modalOutput>  { 

    this.bsModalRef = this.modalService.show(template, { initialState });
    return new Observable<modalOutput>(this.getDataFromModal());

  }
  private getDataFromModal() {
    return (observer) => {
      const subscription = this.modalService.onHidden.subscribe((reason: string) => {
        let modaloutput = new modalOutput();
        modaloutput.outputData = this.bsModalRef.content.output
        modaloutput.reason = reason;
        observer.next(modaloutput);
        observer.complete();
      });
      return {
        unsubscribe() {
          subscription.unsubscribe();
        }
      };
    }
  }
  onClose(reason: string) {
    this.modalService.setDismissReason(reason);
    this.modalService.hide(1);
  }
}
