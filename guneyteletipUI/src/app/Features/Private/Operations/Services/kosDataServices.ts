import { Observable, of } from 'rxjs';
import { ApiDataService } from 'src/app/Shared/Services/Api/apiDataService';
import { Grid } from 'src/app/Shared/Models/UIControls/grid-control';

import { infStudyFilter } from '../Models/infStudyFilter';
import { infStudyViewModel } from '../Models/infStudyViewModel';
import { kosEnumTypeViewModel } from '../Models/kosEnumTypeViewModel';
import { kosModel } from '../Models/kosModel';
import { kosHistoryModel } from '../Models/KosHistoryModel';
import { kosDurumIstModel } from '../Models/kosDurumIstModel';
import { updateKosDurumModel } from '../Models/updateKosDurumModel';

export class kosDataServices {

  constructor(private apiDataService: ApiDataService) { }

  public getKosList(model: Grid.GridInputModel<infStudyFilter>): Observable<Grid.GridOutputModel<infStudyViewModel>> {
    return this.apiDataService.callDataService('Kos/GetKosList', model);
  }
  public changeAccessionNo(model): Observable<any> {
    console.log(model);
    debugger;
    return this.apiDataService.callDataService('Kos/ChangeAccessionNo', model);
  }
//------------------------
  public createKos(model: Grid.GridInputModel<infStudyFilter>): Observable<any> {
    console.log(model);
    return this.apiDataService.callDataService('Kos/CreateKos', model);
  }
  public instanceCreateKos(model: Grid.GridInputModel<infStudyFilter>): Observable<any> {
    console.log(model);
    return this.apiDataService.callDataService('Kos/CreateKosInstance', model);
  }
  public createKosBg(model: infStudyFilter): Observable<number> {
    return this.apiDataService.callDataService('Kos/CreateKosBackground', model);
  }
//-------------------------
  public deleteKos(model: Grid.GridInputModel<infStudyFilter>): Observable<any> {
    return this.apiDataService.callDataService('Kos/DeleteKos', model);
  }
  public deleteFromData(model: Grid.GridInputModel<infStudyFilter>): Observable<any> {
    return this.apiDataService.callDataService('Kos/StudyDataDelete', model);
  }
  public getInstance(model: Grid.GridInputModel<infStudyFilter>): Observable<any> {
      return this.apiDataService.callDataService('Kos/StudyHastaIstanceCek', model);    
  }
  public deleteKosBg(model:infStudyFilter): Observable<number> {
    return this.apiDataService.callDataService('Kos/DeleteKosBackground', model);
  }
  public removeKosStudy(params): Observable<number> {
      return this.apiDataService.callDataService('Kos/RemoveKosStudy', params);
  }
//--------------------------
  public reprocessKos(model: Grid.GridInputModel<infStudyFilter>): Observable<any> {
    return this.apiDataService.callDataService('Kos/ReprocessKos', model);
  }
  public reprocessKosBg(model: infStudyFilter): Observable<number> {
    return this.apiDataService.callDataService('Kos/ReprocessKosBackground', model);
  }
  //----------------------- //UpdateReadKos servisi kaldırıldı ve yerine  StmGetOrderStatusForAccessionNumberlist servisi eklendi.
  public updateReadKos(model: Grid.GridInputModel<infStudyFilter>): Observable<any> {
    return this.apiDataService.callDataService('Kos/UpdateReadKos', model);
  }
  public updateReadKosBg(model: infStudyFilter): Observable<number> { 
    return this.apiDataService.callDataService('Kos/StmGetOrderStatusForAccessionNumberlistBackground', model);
  }
  //-----------------------
  public sendKos(model: Grid.GridInputModel<infStudyFilter>): Observable<any> {
    return this.apiDataService.callDataService('Kos/SendKos', model);
  }
  public sendKosBg(model: infStudyFilter): Observable<number> {
    return this.apiDataService.callDataService('Kos/SendKosBackground', model);
  }
  //-----------------------


  public exportExcel(model: Grid.GridInputModel<infStudyFilter>): Observable<number> {
    return this.apiDataService.callDataService('Kos/ExportExcel', model);
  }
  public getModalityList(): Observable<Array<kosEnumTypeViewModel>> {
    return this.apiDataService.callDataService('Kos/getModalityList', undefined);
  }
  public GetByID(model: kosModel): Observable<infStudyViewModel> {
    return this.apiDataService.callDataService('Kos/GetByID', model);
  }
  public GetKosHistoryByStudyID(model: Grid.GridInputModel<kosHistoryModel>): Observable<Grid.GridOutputModel<kosHistoryModel>> {
    return this.apiDataService.callDataService('Kos/GetKosHistoryByStudyID', model);
  }
  public GetEnumTypeList(): Observable<Array<kosEnumTypeViewModel>> {
    return this.apiDataService.callDataService('Kos/GetEnumTypeList',undefined);
  }
  public GetKosDurumIst(model: infStudyFilter): Observable<Array<kosDurumIstModel>> {
    return this.apiDataService.callDataService('Kos/GetKosDurumIst',model);
  }
  public UpdateKosDurum(model: updateKosDurumModel): Observable<number> {
    return this.apiDataService.callDataService('Kos/UpdateKosDurum', model);
  }
}
