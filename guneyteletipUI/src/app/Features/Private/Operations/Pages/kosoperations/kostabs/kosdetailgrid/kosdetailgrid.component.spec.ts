import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { KosdetailgridComponent } from './kosdetailgrid.component';

describe('KosdetailgridComponent', () => {
  let component: KosdetailgridComponent;
  let fixture: ComponentFixture<KosdetailgridComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ KosdetailgridComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(KosdetailgridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
