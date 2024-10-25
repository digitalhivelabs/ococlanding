import { HttpEvent, HttpHandler, HttpInterceptor, HttpInterceptorFn, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AccountService } from '../_services/account.service';

// export const headerInterceptor: HttpInterceptorFn = (req, next) => {
//   return next(req);
// };


@Injectable()
export class HeaderInterceptor implements HttpInterceptor {

  constructor(private _authService: AccountService) {}

  intercept(httpRequest: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    
    const jwt = this._authService.getCurrentUserToken();
    return next.handle(httpRequest.clone({ setHeaders: { authorization: `Bearer ${jwt}`  }} ));
     
    //return next.handle(httpRequest);
  }
}


