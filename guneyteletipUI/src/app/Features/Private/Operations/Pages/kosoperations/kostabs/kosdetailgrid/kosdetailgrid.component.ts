import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-kosdetailgrid',
  templateUrl: './kosdetailgrid.component.html',
  styleUrls: ['./kosdetailgrid.component.css']
})
export class KosdetailgridComponent implements OnInit {

  @Input() set kosId(value: any) {
    if (value == null || value == undefined)
      return;
    console.log(value);
  }

  constructor() { }

  ngOnInit() {
  }

}
