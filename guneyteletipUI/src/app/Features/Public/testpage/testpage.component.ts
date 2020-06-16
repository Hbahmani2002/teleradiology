import { Component, OnInit } from '@angular/core';
import { userDataServices } from '../../Private/Definitions/Services/userDataServices';
import { UserViewFilter } from '../../Private/Definitions/Models/UserViewFilter';
import { Grid } from 'src/app/Shared/Models/UIControls/grid-control';
import { switchMap, catchError } from 'rxjs/operators';
import { of } from 'rxjs';

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
    var input = new UserViewFilter();
    var model = new Grid.GridInputModel(input);
    this.userService.getUserList(model).subscribe(o => {
      console.log(o);
    });
  }
}
