import { Component, OnInit } from '@angular/core';
import { kosDataServices } from '../../../Services/kosDataServices';
import { kosDurumIstModel } from '../../../Models/kosDurumIstModel';

@Component({
  selector: 'app-kosstatistic',
  templateUrl: './kosstatistic.component.html',
  styleUrls: ['./kosstatistic.component.css']
})
export class KosstatisticComponent implements OnInit {

  public isCollapsed: boolean = true;
  public isCollapsed1: boolean = true;
  kosDurumModel= Array<kosDurumIstModel>();
  constructor(private kosService: kosDataServices) { }

  ngOnInit() {
    this.onRefresh();
  }
  onRefresh() {
    this.kosService.GetKosDurumIst().subscribe(data => {
      console.log(data);
      this.kosDurumModel = data;
    });
  }
}
