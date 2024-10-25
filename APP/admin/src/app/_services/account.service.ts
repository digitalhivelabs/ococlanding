import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import { User } from '../_models/user';
import { SharedService } from './shared.service';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = '';

  private currentUserSource = new BehaviorSubject<User | null>(null);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient, private _shared: SharedService) { 
    this.baseUrl = this._shared.getEnviromentVariables()["account"];
  }

  login(model: any) {

    console.log('trying to make login: ', this.baseUrl + 'login', model);

    return this.http.post<User>(this.baseUrl + 'login', model).pipe(
      map((response: User) => {
        const user = response;
        if (user) {
          localStorage.setItem('user', JSON.stringify(user))
          this.currentUserSource.next(user);
        }
        return user;
      })
    )
  }

  requestCodeForResetPwd(username: string) {

    // var model = {
    //   username: username,
    //   password: 'dummy'
    // }

    return this.http.post<User>(this.baseUrl + 'resetPwdRequest/' + username , null ).pipe(
      map(code => {
        if (code) {
          //localStorage.setItem('user', JSON.stringify(user));
          //this.currentUserSource.next(user);
        }
        return code;
      })
    )    
  }


  requestResetPwd(model: any) {

    console.log('requesting reeset: ', this.baseUrl + 'resetPwd', model);

    return this.http.post<User>(this.baseUrl + 'resetPwd', model).pipe(
      map(result => {
        if (result) {
          //localStorage.setItem('user', JSON.stringify(user));
          //this.currentUserSource.next(user);
        }
        return result;
      })
    )    
  }

  setApproval(model: any) {
    
    this.baseUrl = this._shared.getEnviromentVariables()["users"];

    return this.http.put<any>(this.baseUrl + 'approver', model).pipe(
      map(result => {
        if (result) {
          //localStorage.setItem('user', JSON.stringify(user));
          //this.currentUserSource.next(user);
        }
        return result;
      })
    )    

  }

  getCurrentUserToken() {
    
    const user = JSON.parse(localStorage.getItem("user") || '""');
    
    return user!.token;
  }


  getCurrentUser() {
    
    const user = JSON.parse(localStorage.getItem("user") || '""');
    
    return user;
  }


  register(model: any) {

    return this.http.post<User>(this.baseUrl + 'register', model).pipe(
      map(user => {
        if (user) {
          //localStorage.setItem('user', JSON.stringify(user));
          //this.currentUserSource.next(user);
        }
        return user;
      })
    )
  }

  getAllUsers() {

    //console.log(this.baseUrl + 'users/false');
    ///api/Users/{isActive}
    this.baseUrl = this._shared.getEnviromentVariables()["base"];
    return this.http.get<User>(this.baseUrl + 'users/false');
  }

  setCurrentUser(user: User) {
    this.currentUserSource.next(user);
  }

  logout() {
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
  }
}
