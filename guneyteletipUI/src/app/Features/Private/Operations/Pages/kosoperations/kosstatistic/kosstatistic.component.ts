import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-kosstatistic',
  templateUrl: './kosstatistic.component.html',
  styleUrls: ['./kosstatistic.component.css']
})
export class KosstatisticComponent implements OnInit {

  public isCollapsed: boolean = true;
  public isCollapsed1: boolean = true;

  public enumData: any[] = []
  constructor() { }

  ngOnInit() {
    this.enumData.push({ id: 1, name: 'Kos oluşumu hatalı olanlar', result: 8956 });
    this.enumData.push({ id: 1, name: 'KOS Oluşmamış Olanlar', result: 5236 });
    this.enumData.push({ id: 1, name: 'KOS Oluşmuş Olanlar', result: 7412 });
    this.enumData.push({ id: 1, name: 'KOS Gönderip Eşleşenler', result: 9856 });
    this.enumData.push({ id: 1, name: 'KOS Gönderilip Eşleşmeyenler', result: 4884 });
    this.enumData.push({ id: 1, name: 'KOS Hatalı Gönderilenler', result: 4849 });
    this.enumData.push({ id: 1, name: 'KOS Silinenler', result: 4546 });
  }
  onRefresh() {

  }
}
