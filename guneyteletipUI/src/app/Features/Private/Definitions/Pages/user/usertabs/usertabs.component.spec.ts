import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UsertabsComponent } from './usertabs.component';

describe('UsertabsComponent', () => {
  let component: UsertabsComponent;
  let fixture: ComponentFixture<UsertabsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UsertabsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UsertabsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
