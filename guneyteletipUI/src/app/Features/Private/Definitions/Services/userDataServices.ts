import { Observable } from 'rxjs';
import { ApiDataService } from 'src/app/Shared/Services/Api/apiDataService';

export class userDataServices {

  constructor(private apiDataService: ApiDataService) { }

  public functionName(): Observable<boolean> {
    return this.apiDataService.callDataService('Service/Name', undefined);
  }
}
