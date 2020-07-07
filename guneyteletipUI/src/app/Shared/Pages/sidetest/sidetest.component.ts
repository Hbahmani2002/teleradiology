import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-sidetest',
  templateUrl: './sidetest.component.html',
  styleUrls: ['./sidetest.component.css']
})
export class SidetestComponent implements OnInit {
  public collapse: boolean = true;
  public collapse1: boolean = true;
  constructor() { }

  ngOnInit() {
  }
  toggle() {
    if (this.collapse == true) {
      this.collapse = false;
    }
    else {
      this.collapse = true;
    }
  }
}
