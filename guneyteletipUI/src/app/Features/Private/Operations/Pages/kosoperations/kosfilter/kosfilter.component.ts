import { Component, OnInit } from '@angular/core';
import { IDropdownSettings } from 'ng-multiselect-dropdown';
import { kosDataServices } from '../../../Services/kosDataServices';
import { userDataServices } from 'src/app/Features/Private/Definitions/Services/userDataServices';
import { kosFilter } from '../kosgrid/kosgrid.component';


@Component({
  selector: 'app-kosfilter',
  templateUrl: './kosfilter.component.html',
  styleUrls: ['./kosfilter.component.css']
})
export class KosfilterComponent implements OnInit {


  dropdownList = [];
  selectedItems = [];
  dropdownSettings: IDropdownSettings = {};

  isCollapsed = false;
  public tcKimlikNo: string;
  public tcKimlikNoList: string[] = [];
  public accessionNo: string;
  public accessionNoList: string[] = [];
  public kosFilter: kosFilter = new kosFilter();


  constructor(private kosService: kosDataServices, private userService: userDataServices) {
  }

  ngOnInit() {
    this.dropdownSettings = {
      singleSelection: false,
      idField: 'item_id',
      textField: 'item_text',
      selectAllText: 'Select All',
      unSelectAllText: 'UnSelect All',
      itemsShowLimit: 3,
      allowSearchFilter: true
    };
    this.getTenantList();

  }
 
  //GET MODALITY AND TENANT FOR DROPDOWNLIST
  getTenantList() {
    this.dropdownList.push({ item_id: 1, item_text: 'HAYAT HAST'});
   //this.userService.getTenantList();
  }
  getModalityList() {
    this.kosService.getModalityList().subscribe(data => {
      console.log(data);
    });
  }


  //SPLIT
  split(type) {
    if (type == 'tc') {
      this.tcKimlikNo.split(" ").forEach(item => {
        if (item.length == 11) {
          this.tcKimlikNoList.push(item);
        }
      });
    }
    else if (type = 'accession') {
      this.accessionNo.split(" ").forEach(item => {
        if (item.length == 11) {
          this.accessionNoList.push(item);
        }
      });
    }
  }
}
