import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { KosgridComponent } from './kosgrid.component';

describe('KosgridComponent', () => {
  let component: KosgridComponent;
  let fixture: ComponentFixture<KosgridComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ KosgridComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(KosgridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
