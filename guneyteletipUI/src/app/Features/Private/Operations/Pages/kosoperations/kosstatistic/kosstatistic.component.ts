import { Component, OnInit, Input } from '@angular/core';
import { kosDataServices } from '../../../Services/kosDataServices';
import { kosDurumIstModel } from '../../../Models/kosDurumIstModel';
import { infStudyFilter } from '../../../Models/infStudyFilter';
import { Grid } from 'src/app/Shared/Models/UIControls/grid-control';

import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';

@Component({
  selector: 'app-kosstatistic',
  templateUrl: './kosstatistic.component.html',
  styleUrls: ['./kosstatistic.component.css']
})
export class KosstatisticComponent implements OnInit {
 
  @Input() set filter(value: any) {
    if (value == null || value == undefined)
      return;
    this.kosFilter = value;
    this.onRefresh();
    //his.showMe();
  }
 
  public isCollapsed: boolean = false;
  public isCollapsed1: boolean = true;

  public kosFilter: infStudyFilter = new infStudyFilter(); 

  kosDurumModel= Array<kosDurumIstModel>();
  constructor(private kosService: kosDataServices) {
  
   }
   safeUrl: SafeResourceUrl;
  ngOnInit() {
    this.onRefresh();
   // this.showMe();
  }
 
  onRefresh() {
    this.kosService.GetKosDurumIst(this.kosFilter).subscribe(data => {
      console.log(data);
      this.kosDurumModel = data;
    });
  }
}
