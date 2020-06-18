import { Component, OnInit } from '@angular/core';
import { IDropdownSettings } from 'ng-multiselect-dropdown';
import { kosDataServices } from '../../../Services/kosDataServices';
import { userDataServices } from 'src/app/Features/Private/Definitions/Services/userDataServices';

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
 
  constructor(private kosService: kosDataServices, private userService: userDataServices) {
  }

  ngOnInit() {
    this.dropdownList = [
      
    ];
    this.selectedItems = [
      
    ];
    this.dropdownSettings = {
      singleSelection: false,
      idField: 'item_id',
      textField: 'item_text',
      selectAllText: 'Select All',
      unSelectAllText: 'UnSelect All',
      itemsShowLimit: 3,
      allowSearchFilter: true
    };
  }
  onItemSelect(item: any) {
    console.log(item);
  }
  onSelectAll(items: any) {
    console.log(items);
  }
  splitTc() {
    this.tcKimlikNo.split(" ").forEach(item => {
      if (item.length == 11) {
        this.tcKimlikNoList.push(item);
      }
      
    });
    console.log(this.tcKimlikNoList);
  }
  getHospitalList() {
    this.dropdownList = [

    ];
   //this.userService.getTenantList();
  }
  getModalityList() {
    this.kosService.getModalityList().subscribe(data => {
      console.log(data);
    });
  }

}
