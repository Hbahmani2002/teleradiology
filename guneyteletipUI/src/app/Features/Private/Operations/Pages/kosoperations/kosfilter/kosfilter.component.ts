import { Component, OnInit, Input } from '@angular/core';
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
  public dateRange: any[] = [];
  public tcKimlikNo: string;
  public tcKimlikNoList: string[] = [];
  public accessionNo: string;
  public accessionNoList: string[] = [];
  public kosFilter: kosFilter = new kosFilter();
  public kosFilterOutput: kosFilter = new kosFilter();


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
    this.ddlTenantSelectedItems.forEach(item => {
      this.kosFilter.hastaneList.push(item.tenantAd);
    });
    this.ddlModalitySelectedItems.forEach(item => {
      this.kosFilter.modalite.push(item.name);
    });
    this.ddlEnumSelectedItems.forEach(item => {
      this.kosFilter.eslesmeDurumu.push(item.name);
    });

    this.kosFilter.basTarih = this.dateRange[0];
    this.kosFilter.bitTarih = this.dateRange[1];

    this.kosFilter.tcList = this.splitTC();
    this.kosFilter.accessionNumberList = this.splitAccession();

    debugger;
   
    this.kosFilterOutput = this.kosFilter;
    this.onClearKosFilter();
    console.log(this.kosFilterOutput);
    this.tcKimlikNoList = [];
    this.accessionNoList = [];
    
  }
  onClearKosFilter() {
    this.kosFilter.accessionNumberList = [];
    this.kosFilter.basTarih = undefined;
    this.kosFilter.bitTarih = undefined;
    this.kosFilter.eslesmeDurumu = [];
    this.kosFilter.hastaneList = [];
    this.kosFilter.modalite = [];
    this.kosFilter.tcList = [];
  }
  onClearFilter() {
    this.ddlTenantSelectedItems = [];
    this.ddlModalitySelectedItems = [];
    this.ddlEnumSelectedItems = [];
    this.dateRange = [];
    this.tcKimlikNo = '';
    this.accessionNo = '';
  }
}
