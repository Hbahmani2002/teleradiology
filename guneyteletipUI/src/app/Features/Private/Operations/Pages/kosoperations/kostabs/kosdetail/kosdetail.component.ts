import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-kosdetail',
  templateUrl: './kosdetail.component.html',
  styleUrls: ['./kosdetail.component.css']
})
export class KosdetailComponent implements OnInit {

  @Input() set kosId(value: any) {
    if (value == null || value == undefined)
      return;
    console.log(value);
  }

  constructor() { }

  ngOnInit() {
  }

}
