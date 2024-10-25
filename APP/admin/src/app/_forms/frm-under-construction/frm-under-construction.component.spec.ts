import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FrmUnderConstructionComponent } from './frm-under-construction.component';

describe('FrmUnderConstructionComponent', () => {
  let component: FrmUnderConstructionComponent;
  let fixture: ComponentFixture<FrmUnderConstructionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FrmUnderConstructionComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FrmUnderConstructionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
