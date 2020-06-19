import { Component, OnInit, ViewChild } from '@angular/core';
import { userDataServices } from '../../../Definitions/Services/userDataServices';
import { KosfilterComponent } from './kosfilter/kosfilter.component';

@Component({
  selector: 'app-kosoperations',
  templateUrl: './kosoperations.component.html',
  styleUrls: ['./kosoperations.component.css']
})
export class KosoperationsComponent implements OnInit {

  @ViewChild(KosfilterComponent, { static: false })
  public kosFilterComponent: KosfilterComponent;

  constructor(private userService: userDataServices) { }

  ngOnInit() {
  }

}
