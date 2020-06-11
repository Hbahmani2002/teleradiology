import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { KosstatisticComponent } from './kosstatistic.component';

describe('KosstatisticComponent', () => {
  let component: KosstatisticComponent;
  let fixture: ComponentFixture<KosstatisticComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ KosstatisticComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(KosstatisticComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
