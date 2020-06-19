import { IDropdownSettings } from 'ng-multiselect-dropdown';

export class ddlSettings {
  ddlTenantSettings: IDropdownSettings = {};
  ddlModalitySettings: IDropdownSettings = {};
  ddlStateSettings: IDropdownSettings = {};
  ddlRoleSettings: IDropdownSettings = {};

  constructor() {
    this.ddlTenantSettings = {
      singleSelection: false,
      idField: 'pk',
      textField: 'tenantAd',
      selectAllText: 'Select All',
      unSelectAllText: 'UnSelect All',
      itemsShowLimit: 0,
      allowSearchFilter: true
    };
    this.ddlModalitySettings = {
      singleSelection: false,
      idField: 'pk',
      textField: 'tenantAd',
      selectAllText: 'Select All',
      unSelectAllText: 'UnSelect All',
      itemsShowLimit: 0,
      //allowSearchFilter: true
    };
    this.ddlStateSettings = {
      singleSelection: false,
      idField: 'pk',
      textField: 'tenantAd',
      selectAllText: 'Select All',
      unSelectAllText: 'UnSelect All',
      itemsShowLimit: 0,
      //allowSearchFilter: true
    };
    this.ddlRoleSettings = {
      singleSelection: true,
      idField: 'item_id',
      textField: 'item_text',
    };
  }
}
