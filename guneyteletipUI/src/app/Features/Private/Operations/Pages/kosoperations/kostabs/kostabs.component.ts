import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-kostabs',
  templateUrl: './kostabs.component.html',
  styleUrls: ['./kostabs.component.css']
})
export class KostabsComponent implements OnInit {

  @Input() set kosId(value: any) {
    if (value == null || value == undefined)
      return;
    this.kosID = value;
    console.log(value);
  }
  public kosID;
  constructor() { }

  ngOnInit() {
  }

}
