import { Component, OnInit, Input } from '@angular/core';
import { userDataServices } from '../../../Services/userDataServices';
import { userUIModel } from '../../../Models/UserUIModel';
import { ddlSettings } from 'src/app/Features/Private/Operations/Pages/kosoperations/kosfilter/ddlSettings';

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
    this.userModel.userID = value;
    this.userService.getRoleByID(this.userModel).subscribe(data => {
     // this.ddlRoleSelectedItem = data;
      console.log(data);
    });
    this.userService.getTenantByID(this.userModel).subscribe(data => {
      //this.ddlTenantSelectedItem = data;
      console.log(data);
    });
  }

  ddlSettings: ddlSettings = new ddlSettings();
  userModel: userUIModel = new userUIModel();

  ddlTenantData = [];
  ddlTenantSelectedItem = [];
  ddlTenantDisabled = true;
  ddlTenantSettings;

  ddlRoleData = [];
  ddlRoleSelectedItem = [];
  ddlRoleDisabled = true;
  ddlRoleSettings;
 
  constructor(private userService: userDataServices) { }

  ngOnInit() {
    this.ddlTenantSettings = this.ddlSettings.ddlTenantSettings;
    this.ddlRoleSettings = this.ddlSettings.ddlRoleSettings;
  }
  getDdlRoleData() {
    this.userService.getRolList().subscribe(data => {
      this.ddlRoleData = data;
      console.log(data);
    });
  }
  getDdlTenantData() {
    this.userService.getTenantList().subscribe(data => {
      this.ddlTenantData = data;
      console.log(data);
    });
  }
  onSaveRole() {

  }
  onSaveTenant() {

  }
}
