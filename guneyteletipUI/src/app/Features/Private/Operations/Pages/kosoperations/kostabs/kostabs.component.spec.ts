import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { KostabsComponent } from './kostabs.component';

describe('KostabsComponent', () => {
  let component: KostabsComponent;
  let fixture: ComponentFixture<KostabsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ KostabsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(KostabsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
