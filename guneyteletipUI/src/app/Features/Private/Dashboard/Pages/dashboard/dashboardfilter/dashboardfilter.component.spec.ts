import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DashboardfilterComponent } from './dashboardfilter.component';

describe('DashboardfilterComponent', () => {
  let component: DashboardfilterComponent;
  let fixture: ComponentFixture<DashboardfilterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DashboardfilterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DashboardfilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
