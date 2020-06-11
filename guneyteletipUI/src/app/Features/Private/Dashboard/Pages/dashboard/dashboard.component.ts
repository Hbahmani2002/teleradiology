import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  isCollapsed = false;
  public collapseButtonText: string = 'Filtrelemeyi Kapat';

  constructor() { }

  ngOnInit() {
  }
  collapseEvent() {
    this.isCollapsed = !this.isCollapsed;
    if (this.isCollapsed == true) {
      this.collapseButtonText = 'Filtrelemeyi Aç';
    }
    else {
      this.collapseButtonText = 'Filtrelemeyi Kapat';
    }
  }

}
