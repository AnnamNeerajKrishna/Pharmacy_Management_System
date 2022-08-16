import { ToastrModule, ToastrService } from 'ngx-toastr';
import { HttpError } from './http-error';
import { Router } from '@angular/router';
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TokenInterceptorService implements HttpInterceptor {

  constructor(private toaster:ToastrService) { }
  intercept(req: HttpRequest<any>, next: HttpHandler) {
    /// logic start

     console.log("Hai");
    
    let token = localStorage.getItem('token')

    let jwttoken = req.clone({

      setHeaders: {
        Authorization: 'bearer ' + token
      }
    }) 
    return next.handle(jwttoken)
    .pipe(
      catchError((errormsg:HttpErrorResponse)=>{
        console.log(errormsg);
        if(errormsg.status!=200){
       this.toaster.error(errormsg.error.title);
        
       return throwError(errormsg);
        }
        return throwError(errormsg);
      })
    );
    
  }
}
