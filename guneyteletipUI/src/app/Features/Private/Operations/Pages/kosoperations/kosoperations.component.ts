import { Component, OnInit, ViewChild, SimpleChanges } from '@angular/core';
import { userDataServices } from '../../../Definitions/Services/userDataServices';
import { KosfilterComponent } from './kosfilter/kosfilter.component';
import { kosFilter, KosgridComponent } from './kosgrid/kosgrid.component';
import { UsergridComponent } from '../../../Definitions/Pages/user/usergrid/usergrid.component';

@Component({
  selector: 'app-kosoperations',
  templateUrl: './kosoperations.component.html',
  styleUrls: ['./kosoperations.component.css']
})
export class KosoperationsComponent implements OnInit {

  @ViewChild(KosgridComponent, { static: false })
  public kosGridComponent: KosgridComponent;

  filterData: kosFilter = new kosFilter();
  constructor(private userService: userDataServices) { }

  ngOnInit() {
  }
  filter(filter) {
    this.filterData = filter;
  }
}
