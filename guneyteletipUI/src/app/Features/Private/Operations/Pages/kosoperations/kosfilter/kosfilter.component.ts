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
  public kosFilter: kosFilter = new kosFilter();


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
  //GET MODALITY AND TENANT FOR DROPDOWNLIST
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
  //SPLIT
  splitTC() {
    if (this.tcKimlikNo == "" || this.tcKimlikNo == undefined)
      return;
    this.tcKimlikNo.split(" ").forEach(item => {
      if (item.length == 11) {
        this.tcKimlikNoList.push(item);
      }
    });
    return this.tcKimlikNoList;
  }
  splitAccession() {
    if (this.accessionNo == "" || this.accessionNo == undefined)
      return;
    this.accessionNo.split(" ").forEach(item => {
      if (item.length == 11) {
        this.accessionNoList.push(item);
      }
    });
    return this.accessionNoList;
  }
  onFilter() {
    if (this.ddlTenantSelectedItems.length != 0) {
      this.kosFilter.hastaneIDList = [];
      this.ddlTenantSelectedItems.forEach(item => {
        this.kosFilter.hastaneIDList.push(item.id);
      });
    }
    if (this.ddlModalitySelectedItems.length != 0) {
      this.kosFilter.modalite = [];
      this.ddlModalitySelectedItems.forEach(item => {
        this.kosFilter.modalite.push(item.name);
      });
    }
    if (this.ddlEnumSelectedItems.length != 0) {
      this.kosFilter.eslesmeDurumu = [];
      this.ddlEnumSelectedItems.forEach(item => {
        this.kosFilter.eslesmeDurumu.push(item.name);
      });
    }
    if (this.dateRange != undefined) {
      this.kosFilter.basTarih = this.dateRange[0];
      this.kosFilter.bitTarih = this.dateRange[1];
    }
    if (this.tcKimlikNo != "" || this.tcKimlikNo != undefined) {
      this.kosFilter.tcList = this.splitTC();
    }
    if (this.accessionNo != "" || this.accessionNo != undefined){
      this.kosFilter.accessionNumberList = this.splitAccession();
    }
    this.filterChanged.emit(this.kosFilter);
    // this.onClearKosFilter();
    
  }
  onClearKosFilter() {
    this.kosFilter.accessionNumberList = undefined;
    this.kosFilter.basTarih = undefined;
    this.kosFilter.bitTarih = undefined;
    this.kosFilter.eslesmeDurumu = undefined;
    this.kosFilter.hastaneIDList = undefined;
    this.kosFilter.modalite = undefined;
    this.kosFilter.tcList = undefined;
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
