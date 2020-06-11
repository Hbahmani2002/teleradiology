import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DashboardStatisticComponent } from './dashboard-statistic.component';

describe('DashboardStatisticComponent', () => {
  let component: DashboardStatisticComponent;
  let fixture: ComponentFixture<DashboardStatisticComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DashboardStatisticComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DashboardStatisticComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
