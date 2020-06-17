import { Component, OnInit, Input } from '@angular/core';
import {  IDropdownSettings } from 'ng-multiselect-dropdown';
import { userDataServices } from '../../../Services/userDataServices';
import { concat } from 'rxjs/operators';

@Component({
  selector: 'app-usertabs',
  templateUrl: './usertabs.component.html',
  styleUrls: ['./usertabs.component.css']
})
export class UsertabsComponent implements OnInit {

  
  @Input() set clickedItem(value: any) {
    if (value == undefined)
      return;
    console.log(value)
    this.userService.getRoleByID(value).subscribe(data => {
      console.log(data);
    });
  }
  dropdownListRol = [];
  selectedItemsRol = [];
  dropdownListHosp = [];
  selectedItemsHosp = [];

  dropdownSettings: IDropdownSettings = {};
  dropdownSettings2: IDropdownSettings = {};
 
  dropdownDisabled = true;
  dropdownDisabled1 = true;
  constructor(private userService: userDataServices) { }

  ngOnInit() {
    this.ddlRolData();
    /*this.dropdownList = [
    ];
    this.selectedItems = [
    ];*/
    this.dropdownSettings = {
      singleSelection: false,
      idField: 'item_id',
      textField: 'item_text',
      selectAllText: 'Select All',
      unSelectAllText: 'UnSelect All',
      itemsShowLimit: 3,
      allowSearchFilter: true,
    };
    this.dropdownSettings2 = {
      singleSelection: true,
      idField: 'item_id',
      textField: 'item_text',
    };
  }
  ddlRolData() {
    this.userService.getRolList().subscribe(data => {
      console.log(data);
    });
  }
  ddlHospData() {
    this.userService.getTenantList(null).subscribe(data => {
      console.log(data);
    });
  }

}
