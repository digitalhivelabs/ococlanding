import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { AccountService } from '../../_services/account.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-reset-pwd',
  templateUrl: './reset-pwd.component.html',
  styleUrl: './reset-pwd.component.css'
})
export class ResetPwdComponent implements OnInit{

  resetForm: FormGroup = new FormGroup({});
  codeIsValid = false;
  requestedCode = false;
  username: any = '';
  responseCode: any = '';
  isValidCode = true;
  
  constructor(private _accountService: AccountService, private _toastr: ToastrService, private _fb: FormBuilder, private _router: Router) {}

  ngOnInit(): void {
    this.initializeForm();
  }


  initializeForm() {
    this.resetForm = this._fb.group({
      username: ['', Validators.required],
      resetCode: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(8)]],
      confirmPassword: ['', [Validators.required, this.matchValues('password')]]
    });

    this.resetForm.controls['password'].valueChanges.subscribe({
      next: () => this.resetForm.controls['confirmPassword'].updateValueAndValidity()
    })
  }

  matchValues(matchTo: string): ValidatorFn {
    return (control: AbstractControl) => {
      return control.value === control.parent?.get(matchTo)?.value ? null : {notMatching: true}
    }
  }

  requestCode() {
    console.log('requesting code...', this.resetForm, this.resetForm.value.username);
    this._accountService.requestCodeForResetPwd(this.resetForm.value.username).subscribe({
      next: response => {
        console.log(response);
        this.responseCode = response;
        this.requestedCode = true;
      },
      error: error => this._toastr.error(error.error)
    });

  }

  validateCode() {
    
    if (this.resetForm.value.resetCode == this.responseCode) {
      this.codeIsValid = true;
      this.isValidCode = true;
    } else {
      this.isValidCode = false;
    }
  }

  
  resetPwd() {

    console.log(this.resetForm.value);

    const model = {
      'username': this.resetForm.value.username,
      'password': this.resetForm.value.password
    }

    this._accountService.requestResetPwd(model).subscribe({
      next: response => {
        console.log(response);
        
        this._toastr.success("Password changed successfully, please log in");

        //this._router.navigateByUrl('/dashboard');

      },
      error: error => this._toastr.error(error.error)
    });
    
  }

  cancel() {
    this.isValidCode = true;
    this.responseCode = '';
    this.resetForm.reset();
    this.requestedCode = false;
    this.codeIsValid = false;

  }

  checkDisbled() {

  }

  // private fakeReset() {
  //   const user = {
  //     username: 'majahide',
  //     token: '12345'
  //   }

  //   this._accountService.setCurrentUser(user);
  //   this._router.navigateByUrl('/dashboard');

  // }
}
