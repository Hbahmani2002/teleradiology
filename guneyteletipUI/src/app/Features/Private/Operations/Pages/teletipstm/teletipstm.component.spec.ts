import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TeletipstmComponent } from './teletipstm.component';

describe('TeletipstmComponent', () => {
  let component: TeletipstmComponent;
  let fixture: ComponentFixture<TeletipstmComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TeletipstmComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TeletipstmComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
