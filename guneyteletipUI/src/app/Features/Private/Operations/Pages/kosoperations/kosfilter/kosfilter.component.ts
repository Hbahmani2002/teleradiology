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
  public ddlStateSettings;
  public ddlTenant = [];
  public ddlModality = [];
  public ddlState = [];
  public ddlTenantSelectedItems = [];
  public ddlModalitySelectedItems = [];
  public ddlStateSelectedItems = [];
 

  public isCollapsed = false;
  public dateRange;
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
    this.ddlStateSettings = this.ddlSettings.ddlStateSettings;
    //test için
    this.ddlModality.push({ pk: 1, tenantAd: 'mert11' });
    this.ddlModality.push({ pk: 2, tenantAd: 'mert22' });
    this.ddlModality.push({ pk: 3, tenantAd: 'mert33' });

    this.ddlState.push({ pk: 1, tenantAd: 'mert1' });
    this.ddlState.push({ pk: 2, tenantAd: 'mert2' });
    this.ddlState.push({ pk: 3, tenantAd: 'mert3' });

    this.getTenantList();
    this.getModalityList();

   
  }
  //GET MODALITY AND TENANT FOR DROPDOWNLIST
  getTenantList() {
    this.userService.getTenantList().subscribe(data => {
      this.ddlTenant = data;
      console.log(this.ddlTenant);
    });
  }
  getModalityList() {
    this.kosService.getModalityList().subscribe(data => {
      this.ddlModality = data;
      console.log(this.ddlModality);
    });
  }
  getStateList() {
    //Eşleşme durumu servisi şuan yok
  }
  //SPLIT
  split(type) {
    if (type == 'tc') {
      this.tcKimlikNo.split(" ").forEach(item => {
        if (item.length == 11) {
          this.tcKimlikNoList.push(item);
        }
      });
      return this.tcKimlikNoList;
    }
    else if (type = 'accession') {
      this.accessionNo.split(" ").forEach(item => {
        if (item.length == 11) {
          this.accessionNoList.push(item);
        }
      });
      return this.accessionNoList;
    }
  }

  onFilter() {
    this.ddlTenantSelectedItems.forEach(item => {
      this.kosFilter.hastaneList.push(item.item_text);
    });
    this.kosFilter.basTarih = this.dateRange[0];
    this.kosFilter.bitTarih = this.dateRange[1];

    this.kosFilter.tcList = this.split('tc');
    this.kosFilter.accessionNumberList = this.split('accession');


    this.kosFilterOutput = this.kosFilter;
    console.log(this.kosFilterOutput);
    this.tcKimlikNoList = [];
    this.accessionNoList = [];
    
  }
  clearFilter() {
    this.dateRange = [];
    this.tcKimlikNo = '';
    this.accessionNo = '';
  }
}
