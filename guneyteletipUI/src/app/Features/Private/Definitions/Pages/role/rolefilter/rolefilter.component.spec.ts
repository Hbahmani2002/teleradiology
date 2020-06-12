import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RolefilterComponent } from './rolefilter.component';

describe('RolefilterComponent', () => {
  let component: RolefilterComponent;
  let fixture: ComponentFixture<RolefilterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RolefilterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RolefilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
