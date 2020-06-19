import { Observable } from 'rxjs';
import { ApiDataService } from 'src/app/Shared/Services/Api/apiDataService';
import { Grid } from 'src/app/Shared/Models/UIControls/grid-control';

import { infStudyFilter } from '../Models/infStudyFilter';
import { infStudyViewModel } from '../Models/infStudyViewModel';
import { kosEnumTypeViewModel } from '../Models/kosEnumTypeViewModel';
import { kosModel } from '../Models/kosModel';
import { kosHistoryModel } from '../Models/KosHistoryModel';

export class kosDataServices {

  constructor(private apiDataService: ApiDataService) { }

  public getKosList(model: Grid.GridInputModel<infStudyFilter>): Observable<Grid.GridOutputModel<infStudyViewModel>> {
    return this.apiDataService.callDataService('Kos/GetKosList', model);
  }
  public createKos(model: Grid.GridInputModel<infStudyFilter>): Observable<number> {
    return this.apiDataService.callDataService('Kos/CreateKos', model);
  }
  public deleteKos(model: Grid.GridInputModel<infStudyFilter>): Observable<number> {
    return this.apiDataService.callDataService('Kos/DeleteKos', model);
  }
  public exportExcel(model: Grid.GridInputModel<infStudyFilter>): Observable<string> {
    return this.apiDataService.callDataService('Kos/ExportExcel', model);
  }
  public getModalityList(): Observable<Array<kosEnumTypeViewModel>> {
    return this.apiDataService.callDataService('Kos/getModalityList', undefined);
  }
  public reprocessKos(model: Grid.GridInputModel<infStudyFilter>): Observable<number> {
    return this.apiDataService.callDataService('Kos/ReprocessKos', model);
  }
  public updateReadKos(model: Grid.GridInputModel<infStudyFilter>): Observable<number> {
    return this.apiDataService.callDataService('Kos/UpdateReadKos', model);
  }
  public sendKos(model: Grid.GridInputModel<infStudyFilter>): Observable<number> {
    return this.apiDataService.callDataService('Kos/SendKos', model);
  }
  public GetByID(model: kosModel): Observable<infStudyViewModel> {
    return this.apiDataService.callDataService('Kos/GetByID', model);
  }
  public GetKosHistoryByStudyID(model: kosModel): Observable<kosHistoryModel> {
    return this.apiDataService.callDataService('Kos/GetKosHistoryByStudyID', model);
  }
  public GetEnumTypeList(model: kosModel): Observable<Array<kosEnumTypeViewModel>> {
    return this.apiDataService.callDataService('Kos/GetEnumTypeList', model);
  }
}
