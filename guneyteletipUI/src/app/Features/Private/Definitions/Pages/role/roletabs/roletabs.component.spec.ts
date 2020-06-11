import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RoletabsComponent } from './roletabs.component';

describe('RoletabsComponent', () => {
  let component: RoletabsComponent;
  let fixture: ComponentFixture<RoletabsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RoletabsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RoletabsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
