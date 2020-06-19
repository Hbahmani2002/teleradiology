import { IDropdownSettings } from 'ng-multiselect-dropdown';

export class ddlSettings {
  ddlTenantSettings: IDropdownSettings = {};
  ddlModalitySettings: IDropdownSettings = {};
  ddlEnumSettings: IDropdownSettings = {};
  ddlRoleSettings: IDropdownSettings = {};

  constructor() {
    this.ddlTenantSettings = {
      singleSelection: false,
      idField: 'id',
      textField: 'tenantAd',
      selectAllText: 'Tümünü Seç',
      unSelectAllText: 'Tümünü Kaldır',
      itemsShowLimit: 0,
      allowSearchFilter: true
    };
    this.ddlModalitySettings = {
      singleSelection: false,
      idField: 'id',
      textField: 'name',
      selectAllText: 'Tümünü Seç',
      unSelectAllText: 'Tümünü Kaldır',
      itemsShowLimit: 0,
      //allowSearchFilter: true
    };
    this.ddlEnumSettings = {
      singleSelection: false,
      idField: 'id',
      textField: 'name',
      selectAllText: 'Tümünü Seç',
      unSelectAllText: 'Tümünü Kaldır',
      itemsShowLimit: 0,
      //allowSearchFilter: true
    };
    this.ddlRoleSettings = {
      singleSelection: true,
      idField: 'roleID',
      textField: 'roleName',
    };
  }
}
