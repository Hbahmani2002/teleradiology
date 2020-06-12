import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { KosoperationsComponent } from './kosoperations.component';

describe('KosoperationsComponent', () => {
  let component: KosoperationsComponent;
  let fixture: ComponentFixture<KosoperationsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ KosoperationsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(KosoperationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
