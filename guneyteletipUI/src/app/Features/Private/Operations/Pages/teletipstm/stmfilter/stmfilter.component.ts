import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { ddlSettings } from '../../kosoperations/kosfilter/ddlSettings';
import { kosDataServices } from '../../../Services/kosDataServices';
import { userDataServices } from 'src/app/Features/Private/Definitions/Services/userDataServices';
import { stmDataServices } from '../../../Services/stmDataServices';
import { stmFilter } from '../stmgrid/stmgrid.component';

@Component({
  selector: 'app-stmfilter',
  templateUrl: './stmfilter.component.html',
  styleUrls: ['./stmfilter.component.css']
})
export class StmfilterComponent implements OnInit {

  @Output() filterChanged = new EventEmitter<stmFilter>();
  public ddlSettings: ddlSettings = new ddlSettings();

  public ddlTenantSettings;
  public ddlTenantData = [];
  public ddlTenantSelectedItems = [];

  public ddlEnumSettings;
  public ddlEnumData = [];
  public ddlEnumSelectedItems = [];


  public isCollapsed = false;
  public dateRange;
  public accessionNo: string;

  constructor(private stmService: stmDataServices, private userService: userDataServices,) { }

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
    this.stmService.GetTeletipStatusList().subscribe(data => {
      this.ddlEnumData = data;
      console.log(data);
    });
  }
  onFilter() {
    let filter = new stmFilter();
    if (this.ddlTenantSelectedItems.length != 0) {
      filter.hastaneIDList = [];
      this.ddlTenantSelectedItems.forEach(item => {
        filter.hastaneIDList.push(item.id);
      });
    }
    if (this.ddlEnumSelectedItems.length != 0) {
      filter.teletipStatusIDList = [];
      this.ddlEnumSelectedItems.forEach(item => {
        filter.teletipStatusIDList.push(item.id);
      });
    }
    if (this.dateRange != undefined) {
      filter.basTar = undefined;
      filter.bitTar = undefined;

      filter.basTar = new Date(this.dateRange[0].toDateString());
      filter.bitTar = new Date(this.dateRange[1].toDateString());
    }
    if (this.accessionNo != "" || this.accessionNo != undefined) {
      filter.accessionNumberList = [];
      filter.accessionNumberList = this.splitAccession();
    }
    this.filterChanged.emit(filter);
  }

  onClearFilter() {
    this.ddlTenantSelectedItems = [];
    this.ddlEnumSelectedItems = [];
    this.dateRange = undefined;
  }
  splitAccession() {
    let accessionNoList = [];
    if (this.accessionNo == "" || this.accessionNo == undefined)
      return;
    this.accessionNo.split(" ").forEach(item => {
      if (item != "") {
        accessionNoList.push(item);
      }
    });
    return accessionNoList;
  }
}
