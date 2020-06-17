import { Component, OnInit } from '@angular/core';
import { userDataServices } from '../../Private/Definitions/Services/userDataServices';

import { Grid } from 'src/app/Shared/Models/UIControls/grid-control';
import { switchMap, catchError } from 'rxjs/operators';
import { of } from 'rxjs';
import { userViewFilter } from '../../Private/Definitions/Models/UserViewFilter';

@Component({
  selector: 'app-testpage',
  templateUrl: './testpage.component.html',
  styleUrls: ['./testpage.component.css']
})
export class TestpageComponent implements OnInit {

  constructor(private userService: userDataServices) { }

  ngOnInit() {
  }
  getUserList() {
    var input = new userViewFilter();
    var model = new Grid.GridInputModel(input);
    this.userService.getUserList(model).subscribe(o => {
      console.log(o);
    });
  }
}
