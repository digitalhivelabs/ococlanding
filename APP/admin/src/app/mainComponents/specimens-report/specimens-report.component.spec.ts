import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SpecimensReportComponent } from './specimens-report.component';

describe('SpecimensReportComponent', () => {
  let component: SpecimensReportComponent;
  let fixture: ComponentFixture<SpecimensReportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SpecimensReportComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SpecimensReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
