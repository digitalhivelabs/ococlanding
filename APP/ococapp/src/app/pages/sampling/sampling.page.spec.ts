import { ComponentFixture, TestBed } from '@angular/core/testing';
import { SamplingPage } from './sampling.page';

describe('SamplingPage', () => {
  let component: SamplingPage;
  let fixture: ComponentFixture<SamplingPage>;

  beforeEach(async(() => {
    fixture = TestBed.createComponent(SamplingPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
