import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-kosfilter',
  templateUrl: './kosfilter.component.html',
  styleUrls: ['./kosfilter.component.css']
})
export class KosfilterComponent implements OnInit {

  isCollapsed = false;
  public tcKimlikNo: string;
  public tcKimlikNoList: string[] = [];
  public options: any[] = [{ id: 1, description: 'mert' }, { id: 2, description: 'ali' }, { id: 3, description: 'ahmet' }, { id: 4, description: 'veli' },
    { id: 5, description: 'fesfse' }, { id: 6, description: 'grtg' }, { id: 7, description: 'cvxcx' }, { id: 8, description: 'bnmmbm' },
    { id: 9, description: 'yttttttfy' }, { id: 10, description: 'şpopo' }, { id: 11, description: 'öjköj' }, { id: 12, description: 'jyuyg' },
    { id: 9, description: 'yttttttfy' }, { id: 10, description: 'şpopo' }, { id: 11, description: 'öjköj' }, { id: 12, description: 'jyuyg' },
    { id: 9, description: 'yttttttfy' }, { id: 10, description: 'şpopo' }, { id: 11, description: 'öjköj' }, { id: 12, description: 'jyuyg' },
    { id: 9, description: 'yttttttfy' }, { id: 10, description: 'şpopo' }, { id: 11, description: 'öjköj' }, { id: 12, description: 'jyuyg' }];
  config = {
    displayKey: "description", //if objects array passed which key to be displayed defaults to description
    search: true, //true/false for the search functionlity defaults to false,
    height: 'auto', //height of the list so that if there are more no of items it can show a scroll defaults to auto. With auto height scroll will never appear
    placeholder: 'Hastane Seçimi', // text to be displayed when no item is selected defaults to Select,
    customComparator: () => { }, // a custom function using which user wants to sort the items. default is undefined and Array.sort() will be used in that case,
    limitTo: this.options.length, // a number thats limits the no of options displayed in the UI similar to angular's limitTo pipe
    moreText: 'daha hastane', // text to be displayed whenmore than one items are selected like Option 1 + 5 more
    noResultsFound: 'Sonuç Bulunamadı!', // text to be displayed when no items are found while searching
    searchPlaceholder: 'Search', // label thats displayed in search input,
    searchOnKey: 'description', // key on which search should be performed this will be selective search. if undefined this will be extensive search on all keys
    clearOnSelection: false, // clears search criteria when an option is selected if set to true, default is false
    inputDirection: 'ltr', // the direction of the search input can be rtl or ltr(default)
  };
  constructor() {
  }

  ngOnInit() {
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
