import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { AccountService } from '../../_services/account.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-profile-register',
  templateUrl: './profile-register.component.html',
  styleUrl: './profile-register.component.css'
})
export class ProfileRegisterComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  registerForm: FormGroup = new FormGroup({});
  maxDate: Date = new Date();
  registered = false;

  constructor(private _accountService: AccountService, private _toastr: ToastrService, private _fb: FormBuilder) {}

  ngOnInit(): void {
    this.initializeForm();
    this.maxDate.setFullYear(this.maxDate.getFullYear() - 18);
  }

  initializeForm() {
    this.registerForm = this._fb.group({
      gender: ['male'],
      username: ['', Validators.required],
      email: ['', Validators.required],
      job: ['', Validators.required],
      country: ['Mexico', Validators.required],
      password: ["", [Validators.required, Validators.minLength(4), Validators.maxLength(8)]],
      confirmPassword: ['', [Validators.required, this.matchValues('password')]],
      agree: [false, Validators.required]
    });

    this.registerForm.controls['password'].valueChanges.subscribe({
      next: () => this.registerForm.controls['confirmPassword'].updateValueAndValidity()
    })
  }

  matchValues(matchTo: string): ValidatorFn {
    return (control: AbstractControl) => {
      return control.value === control.parent?.get(matchTo)?.value ? null : {notMatching: true}
    }
  }

  register() {
  
    this._accountService.register(this.registerForm.value).subscribe({
      next: response => {
        console.log('response after registered...', response);
        this.registered = true;
        this.cancel();
      },
      error: error => this._toastr.error(error.error)
    })
  }

  checkDisbled(){
    if(this.registerForm.invalid || !this.registerForm.value.agree){ // <- add number of validation
      return true;
    }
    else {
      return false;
    }
  }

  cancel() {
    //this.cancelRegister.emit(false);
    this.registerForm.reset();
    this.registerForm.patchValue({
      country: 'Mexico',
      gender: 'male',
      agree: false
   });
  }
}
