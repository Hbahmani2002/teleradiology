import { Component, OnInit } from '@angular/core';
import { kosFilter } from '../kosoperations/kosgrid/kosgrid.component';

@Component({
  selector: 'app-teletipstm',
  templateUrl: './teletipstm.component.html',
  styleUrls: ['./teletipstm.component.css']
})
export class TeletipstmComponent implements OnInit {
  filterData: kosFilter = new kosFilter();
  constructor() { }

  ngOnInit() {
  }
  filter(filter) {
    this.filterData = filter;
  }
}
