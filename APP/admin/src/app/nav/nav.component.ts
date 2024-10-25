import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { Observable, of } from 'rxjs';
import { User } from '../_models/user';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent implements OnInit {
  model: any = {};

  constructor(public _accountService: AccountService, private _router: Router, private _toastr: ToastrService) {}

  ngOnInit(): void {
  }

  login() {
    
    this._accountService.login(this.model).subscribe({
      next: _ => {
        console.log('logged');
        this._router.navigateByUrl('/dashboard');
      }//this._router.navigateByUrl('/dashboard') //Se puede hacer uso de un _ o () es lo mismo.
    });
    

  }

  logout() {
    this._router.navigateByUrl('/');
    this._accountService.logout();
  }

}
