import { Observable } from 'rxjs';
import { ApiDataService } from 'src/app/Shared/Services/Api/apiDataService';
import { Grid } from 'src/app/Shared/Models/UIControls/grid-control';
import { jobViewmodel } from '../Models/jobViewmodel';
import { jobViewFilter } from '../Models/jobViewFilter';
import { saveJobModel } from '../Models/saveJobModel';


export class jobDataServices {

  constructor(private apiDataService: ApiDataService) { }

  public getJobList(model: Grid.GridInputModel<jobViewFilter>): Observable<Grid.GridOutputModel<jobViewmodel>> {
    return this.apiDataService.callDataService('job/GetJobList', model);
  }
  public save(model: saveJobModel): Observable<number> {
    return this.apiDataService.callDataService('Job/Save', model);
  }
}
