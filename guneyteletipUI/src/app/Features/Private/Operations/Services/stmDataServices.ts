import { Observable, of } from 'rxjs';
import { ApiDataService } from 'src/app/Shared/Services/Api/apiDataService';
import { Grid } from 'src/app/Shared/Models/UIControls/grid-control';
import { GetorderStatusViewFilter } from '../Models/GetorderStatusViewFilter';
import { GetorderStatusViewModel } from '../Models/GetorderStatusViewModel';
import { TeletipStatusViewModel } from '../Models/TeletipStatusViewModel';

export class kosDataServices {

  constructor(private apiDataService: ApiDataService) { }

  public GetGetorderStatusList(model: Grid.GridInputModel<GetorderStatusViewFilter>): Observable<Grid.GridOutputModel<GetorderStatusViewModel>> {
    return this.apiDataService.callDataService('GetorderStatus/GetJobList', model);
  }
  public GetTeletipStatusList(): Observable<Array<TeletipStatusViewModel>> {
    return this.apiDataService.callDataService('GetorderStatus/GetTeletipStatusList', undefined);
  }
}
