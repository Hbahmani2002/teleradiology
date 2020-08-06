import { Injectable } from '@angular/core';
import { parameters } from '../../Consts/parameters';
import { ApiDataService } from '../Api/apiDataService';

@Injectable({
  providedIn: 'root'
})
export class FileService{

  constructor(private apiDataService: ApiDataService) { }
  public download(fileID, newTab: number = 1) {
    if (!fileID)
      return;
    var url = parameters.serverAddress + "FileOperation/Download?fileID=" + fileID;
    console.log("Download statrting..." + url);
    if (newTab == 1)
      this.downloadUrlWindow(url);
    else {
      this.downloadUrl(url);
    }
  }

  private downloadUrl(url) {
    var iframe = document.createElement("iframe");
    iframe.src = url;
    iframe.style.display = "none";
    document.body.appendChild(iframe);
  }
  private downloadUrlWindow(url) {
    window.open(url, 'Download');
  }
  public Download(fileID: number) {
    debugger;
    this.apiDataService.callDataService('FileOperation/Download', { "FileID" : fileID }).subscribe();
  }
}
