import { Component, OnInit, ViewChild } from '@angular/core';
import { userDataServices } from '../../../Definitions/Services/userDataServices';
import { KosfilterComponent } from './kosfilter/kosfilter.component';
import { kosFilter } from './kosgrid/kosgrid.component';

@Component({
  selector: 'app-kosoperations',
  templateUrl: './kosoperations.component.html',
  styleUrls: ['./kosoperations.component.css']
})
export class KosoperationsComponent implements OnInit {

  /*@ViewChild(KosfilterComponent, { static: false })
  public kosFilterComponent: KosfilterComponent;*/
  filterData: kosFilter = new kosFilter();
  constructor(private userService: userDataServices) { }

  ngOnInit() {
  }
  filter(filterData: kosFilter) {
    //debugger;
    this.filterData = filterData;
  }
}
