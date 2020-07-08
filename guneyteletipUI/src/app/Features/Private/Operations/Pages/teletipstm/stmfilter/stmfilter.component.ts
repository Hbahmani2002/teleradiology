import { Component, OnInit } from '@angular/core';
import { ddlSettings } from '../../kosoperations/kosfilter/ddlSettings';
import { kosDataServices } from '../../../Services/kosDataServices';
import { userDataServices } from 'src/app/Features/Private/Definitions/Services/userDataServices';

@Component({
  selector: 'app-stmfilter',
  templateUrl: './stmfilter.component.html',
  styleUrls: ['./stmfilter.component.css']
})
export class StmfilterComponent implements OnInit {

  public ddlSettings: ddlSettings = new ddlSettings();

  public ddlTenantSettings;
  public ddlTenantData = [];
  public ddlTenantSelectedItems = [];

  public ddlEnumSettings;
  public ddlEnumData = [];
  public ddlEnumSelectedItems = [];

  constructor(private kosService: kosDataServices, private userService: userDataServices) { }

  ngOnInit() {
    this.ddlTenantSettings = this.ddlSettings.ddlTenantSettings;
    this.ddlEnumSettings = this.ddlSettings.ddlEnumSettings;

    this.getTenantList();
    this.getEnumList();
  }
  getTenantList() {
    this.userService.getTenantList().subscribe(data => {
      this.ddlTenantData = data;
      console.log(this.ddlTenantData);
    });
  }
  getEnumList() {
    this.kosService.GetEnumTypeList().subscribe(data => {
      this.ddlEnumData = data;
      console.log(data);
    });
  }
}
