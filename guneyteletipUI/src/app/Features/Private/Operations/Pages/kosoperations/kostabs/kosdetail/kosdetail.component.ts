import { Component, OnInit, Input } from '@angular/core';
import { kosModel } from '../../../../Models/kosModel';
import { kosDataServices } from '../../../../Services/kosDataServices';
import { infStudyViewModel } from '../../../../Models/infStudyViewModel';


@Component({
  selector: 'app-kosdetail',
  templateUrl: './kosdetail.component.html',
  styleUrls: ['./kosdetail.component.css']
})
export class KosdetailComponent implements OnInit {

  @Input() set kosId(value: any) {
    if (value == null || value == undefined)
      return;
    console.log(value);
    this.kosModel.id = 2 // value;
    this.kosService.GetByID(this.kosModel).subscribe(data => {
      console.log(data);
      this.kosDetailModel = data;
    });
  }
  kosModel: kosModel = new kosModel();
  kosDetailModel: infStudyViewModel = new infStudyViewModel();
  constructor(private kosService: kosDataServices) { }

  ngOnInit() {
  }

}
