import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SpecimenSummaryComponent } from './specimen-summary.component';

describe('SpecimenSummaryComponent', () => {
  let component: SpecimenSummaryComponent;
  let fixture: ComponentFixture<SpecimenSummaryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SpecimenSummaryComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SpecimenSummaryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
