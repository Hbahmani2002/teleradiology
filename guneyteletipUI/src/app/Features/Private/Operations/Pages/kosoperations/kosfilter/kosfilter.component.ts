import { Component, OnInit } from '@angular/core';
import { IDropdownSettings } from 'ng-multiselect-dropdown';

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
 
  constructor() {
  }

  ngOnInit() {
    this.dropdownList = [
      { item_id: 1, item_text: 'Mumbai' },
      { item_id: 2, item_text: 'Bangaluru' },
      { item_id: 3, item_text: 'Pune' },
      { item_id: 4, item_text: 'Navsari' },
      { item_id: 5, item_text: 'New Delhi' },
      { item_id: 6, item_text: 'Mumbai' },
      { item_id: 7, item_text: 'Bangaluru' },
      { item_id: 8, item_text: 'Pune' },
      { item_id: 9, item_text: 'Navsari' },
      { item_id: 10, item_text: 'New Delhi' },
      { item_id: 11, item_text: 'Mumbai' },
      { item_id: 12, item_text: 'Bangaluru' },
      { item_id: 13, item_text: 'Pune' },
      { item_id: 14, item_text: 'Navsari' },
      { item_id: 15, item_text: 'New Delhi' },
      { item_id: 16, item_text: 'Mumbai' },
      { item_id: 17, item_text: 'Bangaluru' },
      { item_id: 18, item_text: 'Pune' },
      { item_id: 19, item_text: 'Navsari' },
      { item_id: 20, item_text: 'New Delhi' },
      { item_id: 21, item_text: 'Mumbai' },
      { item_id: 22, item_text: 'Bangaluru' },
      { item_id: 23, item_text: 'Pune' },
      { item_id: 24, item_text: 'Navsari' },
      { item_id: 25, item_text: 'New Delhi' },
      { item_id: 26, item_text: 'Mumbai' },
      { item_id: 27, item_text: 'Bangaluru' },
      { item_id: 28, item_text: 'Pune' },
      { item_id: 29, item_text: 'Navsari' },
      { item_id: 30, item_text: 'New Delhi' },

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

}
