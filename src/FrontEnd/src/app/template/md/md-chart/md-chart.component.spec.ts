import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MdChartComponent } from './md-chart.component';

describe('MdChartComponent', () => {
  let component: MdChartComponent;
  let fixture: ComponentFixture<MdChartComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MdChartComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MdChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
