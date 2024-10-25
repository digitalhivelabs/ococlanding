import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SpecimenChartsComponent } from './specimen-charts.component';

describe('SpecimenChartsComponent', () => {
  let component: SpecimenChartsComponent;
  let fixture: ComponentFixture<SpecimenChartsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SpecimenChartsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SpecimenChartsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
