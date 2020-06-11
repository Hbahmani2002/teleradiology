import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { KosfilterComponent } from './kosfilter.component';

describe('KosfilterComponent', () => {
  let component: KosfilterComponent;
  let fixture: ComponentFixture<KosfilterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ KosfilterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(KosfilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
