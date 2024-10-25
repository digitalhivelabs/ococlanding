import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UsersApprovalsComponent } from './users-approvals.component';

describe('UsersApprovalsComponent', () => {
  let component: UsersApprovalsComponent;
  let fixture: ComponentFixture<UsersApprovalsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UsersApprovalsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UsersApprovalsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
