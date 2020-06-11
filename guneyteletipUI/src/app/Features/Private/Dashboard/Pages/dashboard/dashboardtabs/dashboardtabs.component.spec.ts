import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DashboardtabsComponent } from './dashboardtabs.component';

describe('DashboardtabsComponent', () => {
  let component: DashboardtabsComponent;
  let fixture: ComponentFixture<DashboardtabsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DashboardtabsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DashboardtabsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
