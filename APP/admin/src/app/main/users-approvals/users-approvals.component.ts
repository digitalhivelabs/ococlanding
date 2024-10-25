import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../_services/account.service';

@Component({
  selector: 'app-users-approvals',
  templateUrl: './users-approvals.component.html',
  styleUrl: './users-approvals.component.css'
})
export class UsersApprovalsComponent implements OnInit {

  currentUserLogged: any;
  users: any;
  originalUserType = '';

  constructor(private _accountService: AccountService) {
  }

  ngOnInit(): void {
    this.loadAllUsers();
    this.loadCurrentUserLogged();    
  }

  loadCurrentUserLogged() {
    this.currentUserLogged = this._accountService.getCurrentUser();
    console.log('user loaded: ', this.currentUserLogged);
  }

  loadAllUsers() {
    this._accountService.getAllUsers().subscribe({
      next: response => { 
        console.log(response);
        this.users = response 
      }
    });

  }

  approve(user: any) {

    console.log(user);

    const model = {
      "userId": user.id,
      "isApproved": true,
      "role": user.role
    };

    this._accountService.setApproval(model).subscribe({
      next: response => { 
        console.log(response);
        user.status = "Approved";
      }
    });



  }

  reject(user: any) {

    const model = {
      "userId": user.id,
      "isApproved": false,
      "role": user.role
    };

    this._accountService.setApproval(model).subscribe({
      next: response => { 
        console.log(response);
        user.status = "Reject";
      }
    });
  }

  edit(user: any) {
    this.originalUserType = user.role;
    user.editMode = true;
  }

  update(user: any) {
    user.editMode = false;
  }

  cancelUpdate(user: any) {
    user.role = this.originalUserType;
    user.editMode = false;
  }

}
