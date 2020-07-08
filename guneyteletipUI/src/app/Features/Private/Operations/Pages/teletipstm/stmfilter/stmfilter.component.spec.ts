import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StmfilterComponent } from './stmfilter.component';

describe('StmfilterComponent', () => {
  let component: StmfilterComponent;
  let fixture: ComponentFixture<StmfilterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StmfilterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StmfilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
