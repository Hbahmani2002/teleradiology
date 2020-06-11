import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GridtoolsComponent } from './gridtools.component';

describe('GridtoolsComponent', () => {
  let component: GridtoolsComponent;
  let fixture: ComponentFixture<GridtoolsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GridtoolsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GridtoolsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
