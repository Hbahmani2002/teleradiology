import { Component, OnInit } from '@angular/core';
import { userDataServices } from '../../Private/Definitions/Services/userDataServices';

import { Grid } from 'src/app/Shared/Models/UIControls/grid-control';
import { switchMap, catchError } from 'rxjs/operators';
import { of } from 'rxjs';
import { userViewFilter } from '../../Private/Definitions/Models/UserViewFilter';
import { infStudyFilter } from '../../Private/Operations/Models/infStudyFilter';
import { kosDataServices } from '../../Private/Operations/Services/kosDataServices';
import { kosModel } from '../../Private/Operations/Models/kosModel';
import { kosHistoryModel } from '../../Private/Operations/Models/KosHistoryModel';

@Component({
  selector: 'app-testpage',
  templateUrl: './testpage.component.html',
  styleUrls: ['./testpage.component.css']
})
export class TestpageComponent implements OnInit {

  constructor(private userService: userDataServices , private kosService : kosDataServices) { }

  ngOnInit() {
  }
  getUserList() {
    var input = new userViewFilter();
    var model = new Grid.GridInputModel(input);
    this.userService.getUserList(model).subscribe(o => {
      console.log(o);
    });
  }
  getKosList() {
    var input = new infStudyFilter();
    var model = new Grid.GridInputModel(input);
    this.kosService.getKosList(model).subscribe(o => {
      console.log(o);
    });
  }
  getByID() {
    var input = new kosModel();
    input.id = 2
    this.kosService.GetByID(input).subscribe(o => {
      console.log(o);
    });
  }
  getistatistic() {

    this.kosService.GetKosDurumIst().subscribe(o => {
      console.log(o);
    });
  }
  getKosHistoryByStudyId() {
    var input = new kosHistoryModel();
    var model = new Grid.GridInputModel(input);

    this.kosService.GetKosHistoryByStudyID(model).subscribe(o => {
      console.log(o);
    });
  }
}
