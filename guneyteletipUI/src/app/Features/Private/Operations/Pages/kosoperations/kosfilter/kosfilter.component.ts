import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { IDropdownSettings } from 'ng-multiselect-dropdown';
import { kosDataServices } from '../../../Services/kosDataServices';
import { userDataServices } from 'src/app/Features/Private/Definitions/Services/userDataServices';
import { kosFilter } from '../kosgrid/kosgrid.component';
import { ddlSettings } from './ddlSettings';


@Component({
  selector: 'app-kosfilter',
  templateUrl: './kosfilter.component.html',
  styleUrls: ['./kosfilter.component.css']
})
export class KosfilterComponent implements OnInit {

  @Output() filterChanged = new EventEmitter<kosFilter>();

  public ddlSettings: ddlSettings = new ddlSettings();

  public ddlTenantSettings;
  public ddlModalitySettings;
  public ddlEnumSettings;
  public ddlTenantData = [];
  public ddlModalityData = [];
  public ddlEnumData = [];
  public ddlTenantSelectedItems = [];
  public ddlModalitySelectedItems = [];
  public ddlEnumSelectedItems = [];
 
  public isCollapsed = false;
  public dateRange;
  public tcKimlikNo: string;
  public tcKimlikNoList: string[] = [];
  public accessionNo: string;
  public accessionNoList: string[] = [];

  constructor(private kosService: kosDataServices, private userService: userDataServices) {
  }
  ngOnInit() {
   
    this.ddlTenantSettings = this.ddlSettings.ddlTenantSettings;
    this.ddlModalitySettings = this.ddlSettings.ddlModalitySettings;
    this.ddlEnumSettings = this.ddlSettings.ddlEnumSettings;

    this.getTenantList();
    this.getModalityList();
    this.getEnumList();
   
  }
  getTenantList() {
    this.userService.getTenantList().subscribe(data => {
      this.ddlTenantData = data;
      console.log(this.ddlTenantData);
    });
  }
  getModalityList() {
    this.kosService.getModalityList().subscribe(data => {
      this.ddlModalityData = data;
      console.log(this.ddlModalityData);
    });
  }
  getEnumList() {
    this.kosService.GetEnumTypeList().subscribe(data => {
      this.ddlEnumData = data;
      console.log(data);
    });
  }
  splitTC() {
    let tcKimlikNoList = [];
    if (this.tcKimlikNo == "" || this.tcKimlikNo == undefined)
      return;
    this.tcKimlikNo.split(" ").forEach(item => {
      if (item.length == 11) {
        tcKimlikNoList.push(item);
      }
    });
    return tcKimlikNoList;
  }
  splitAccession() {
    let accessionNoList = [];
    if (this.accessionNo == "" || this.accessionNo == undefined)
      return;
    this.accessionNo.split(" ").forEach(item => {
      debugger;
      if (item != "") {
       accessionNoList.push(item);
      }
    });
    return accessionNoList;
  }
  onFilter() {
    let filter = new kosFilter();
    if (this.ddlTenantSelectedItems.length != 0) {
      filter.hastaneIDList = [];
      this.ddlTenantSelectedItems.forEach(item => {
        filter.hastaneIDList.push(item.id);
      });
    }
    if (this.ddlModalitySelectedItems.length != 0) {
      filter.modaliteList = [];
      this.ddlModalitySelectedItems.forEach(item => {
        filter.modaliteList.push(item.name);
      });
    }
    if (this.ddlEnumSelectedItems.length != 0) {
      filter.EslesmeDurumuList = [];
      this.ddlEnumSelectedItems.forEach(item => {
        filter.EslesmeDurumuList.push(item.id);
      });
    }
    if (this.dateRange != undefined) {
      filter.basTarih = undefined;
      filter.bitTarih = undefined;

      filter.basTarih = new Date(this.dateRange[0].toDateString());
      filter.bitTarih = new Date(this.dateRange[1].toDateString());
    }
    if (this.tcKimlikNo != "" || this.tcKimlikNo != undefined) {
      filter.tcList = [];
      filter.tcList = this.splitTC();
    }
    if (this.accessionNo != "" || this.accessionNo != undefined) {
      filter.accessionNumberList = [];
      filter.accessionNumberList = this.splitAccession();
    }
    this.filterChanged.emit(filter);
  }

  onClearFilter() {
    this.ddlTenantSelectedItems = [];
    this.ddlModalitySelectedItems = [];
    this.ddlEnumSelectedItems = [];
    this.dateRange = undefined;
    this.tcKimlikNo = undefined;
    this.accessionNo = undefined;
  }
}
