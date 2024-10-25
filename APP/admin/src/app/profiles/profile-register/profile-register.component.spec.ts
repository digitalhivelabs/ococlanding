import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfileRegisterComponent } from './profile-register.component';

describe('ProfileRegisterComponent', () => {
  let component: ProfileRegisterComponent;
  let fixture: ComponentFixture<ProfileRegisterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ProfileRegisterComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ProfileRegisterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
