import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpInterceptorFn, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NavigationExtras, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable, catchError } from 'rxjs';

// export const errorInterceptor: HttpInterceptorFn = (req, next) => {
//   return next(req);
// };

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(private _router: Router, private _toastr: ToastrService ) {}

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
      return next.handle(req).pipe(
        catchError((error: HttpErrorResponse) => {
          if (error) {
            switch(error.status) {
              case 400:
                if (error.error.errors) {
                  const modelStateErrors = [];
                  for(const key in error.error.errors) {
                    if (error.error.errors[key]) {
                      modelStateErrors.push(error.error.errors[key]);
                    }
                  }
                  throw modelStateErrors.flat();
                } else {
                  this._toastr.error(error.error, error.status.toString())
                }
                break;
              case 401:
                this._toastr.error("Unauthorized", error.status.toString())
                break;
              case 404:
                this._router.navigateByUrl('/not-found');
                break;
              case 500:
                const navigationExtras: NavigationExtras = { state: {error: error.error}};
                this._router.navigateByUrl('/server-error', navigationExtras);
                break;
              default:
                this._toastr.error('Something unexpected goes wrong');
                console.log(error);
                break;
            }
          }
          throw error;
        })
      )
    }
}
