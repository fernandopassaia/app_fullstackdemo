import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FixedpluginComponent } from './fixedplugin.component';

describe('FixedpluginComponent', () => {
  let component: FixedpluginComponent;
  let fixture: ComponentFixture<FixedpluginComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FixedpluginComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FixedpluginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
