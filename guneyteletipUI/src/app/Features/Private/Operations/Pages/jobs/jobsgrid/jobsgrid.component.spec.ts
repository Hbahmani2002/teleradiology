import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { JobsgridComponent } from './jobsgrid.component';

describe('JobsgridComponent', () => {
  let component: JobsgridComponent;
  let fixture: ComponentFixture<JobsgridComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ JobsgridComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(JobsgridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
