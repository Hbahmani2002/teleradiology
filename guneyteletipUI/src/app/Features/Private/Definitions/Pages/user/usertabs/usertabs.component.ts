import { Component, OnInit, Input } from '@angular/core';
import { userDataServices } from '../../../Services/userDataServices';
import { userUIModel } from '../../../Models/UserUIModel';
import { ddlSettings } from 'src/app/Features/Private/Operations/Pages/kosoperations/kosfilter/ddlSettings';
import { saveRolUIModel } from '../../../Models/SaveRolUIModel';
import { saveTenantUIModel } from '../../../Models/SaveTenantUIModel';

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
    this.saveRole.UserID = value;
    this.userModel.userID = value;
    this.saveTenat.userID = value
    this.getDdlRoleSelectedItems();
    this.getDdlTenantSelectedItems();
  }

  ddlSettings: ddlSettings = new ddlSettings();
  userModel: userUIModel = new userUIModel();
  saveRole: saveRolUIModel = new saveRolUIModel();
  saveTenat: saveTenantUIModel = new saveTenantUIModel();

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
    this.getDdlRoleData();
    this.getDdlTenantData();
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
  getDdlTenantSelectedItems() {
    this.userService.GetTenantListByUserID(this.userModel).subscribe(data => {
      this.ddlTenantSelectedItem = data;
      console.log(data);
    });
  }
  getDdlRoleSelectedItems() {
    debugger;
    this.userService.getRoleByID(this.userModel).subscribe(data => {
      debugger;
      this.ddlRoleSelectedItem.push(data);
    });
  }
  onSaveRole() {
    if (this.ddlRoleDisabled) {
      this.saveRole.RolID = this.ddlRoleSelectedItem[0].roleID;
      debugger;
      console.log(this.saveRole);
      this.userService.saveRol(this.saveRole).subscribe(o => {
        console.log(o);
      });

    }
  }
  onSaveTenant() {
    if (this.ddlRoleDisabled) {
      this.saveTenat.tenantIDList = [];
      this.ddlTenantSelectedItem.forEach(item => {
        this.saveTenat.tenantIDList.push(item.id);
      })
      console.log(this.saveTenat)
      this.userService.saveTenant(this.saveTenat).subscribe(o => {
        console.log(o);
      });

    }
  }
}
