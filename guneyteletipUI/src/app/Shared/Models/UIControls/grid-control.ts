export namespace Grid {
  export class Sorting {
    public colName: string;
    public direction: number = 0;
  }
  export class Paging {
    public pageNumber: number = 1;
    public count: number = 10;
  }
  export class GridInputModel<TFilter> {
    public filter: TFilter;
    public paging: Paging = new Paging();
    public sorting: Sorting ;
    constructor(filter: TFilter) {
      this.filter = filter;
    }
  }
  export class GridOutputModel<T> {
    list: T[];
    totalCount: number;
  }

  export class GridControl<T> {
    clickedItem: any;
    selectedItems: any[];
    pager: number[] = [10, 25, 50];
    totalCount: number;
    data: GridOutputModel<T>;
    model: GridControlModel;

    constructor() {
      this.selectedItems = [];
      this.data = { list: [], totalCount: 0 };
      this.model = new GridControlModel();

    };
    getRowClass(item: any) {
      if (this.isSelected(item)) {
        return 'table-success';
      } else {
        if (this.clickedItem == item)
          return 'table-info';
        return ''
      }
    };
    isSelected(item: any) {
      return this.selectedItems.includes(item);
    };
    onClearPaging() {
      this.model.paging.pageNumber = 0;
      this.model.paging.count = this.model.paging.count;
    };
    hasSelectedItem() {
      return this.selectedItems.length > 0;
    };
    onPageChanged(event) {
      var page = event.page;
      this.model.paging.pageNumber = page;
      this.onRefresh();
    }
    onClearFilter() {
      this.model.filter = {};
      this.onRefresh();
    };
    onDelete() {


    };
    onSelectAll(event: any) {
      if (!event.srcElement.checked) {
        this.selectedItems.length = 0;
        return;
      }
      this.selectedItems.length = 0;
      this.data.list.forEach(o => {
        this.onSelectItem(o);
      });
    };
    onClickItem(item: any) {
      this.clickedItem = item;

    };
    onSelectItem(item: any) {
      if (this.isSelected(item)) {
        var ar = this.selectedItems;
        var index = ar.indexOf(item);
        if (index > -1) {
          ar.splice(index, 1);
        }
        return;
      }
      this.selectedItems.push(item);

    };
    onRefresh() {

    };



  }

  export class GridControlModel {

    filter_state: any = {};
    filter: any;
    paging = new Paging();
    sorting = new Sorting();
    constructor() {
    }
  };


}
