import { Observable } from 'rxjs';
import { ApiDataService } from 'src/app/Shared/Services/Api/apiDataService';
import { Grid } from 'src/app/Shared/Models/UIControls/grid-control';

import { infStudyFilter } from '../Models/infStudyFilter';
import { infStudyViewModel } from '../Models/infStudyViewModel';

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
  public getModalityList(): Observable<any> {
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
}
