import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StmgridComponent } from './stmgrid.component';

describe('StmgridComponent', () => {
  let component: StmgridComponent;
  let fixture: ComponentFixture<StmgridComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StmgridComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StmgridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
