import { LoginService } from './../Shared/login.service';
import { Injectable } from '@angular/core';
import {  CanActivate, Router } from '@angular/router';


@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private router:Router,private service:LoginService){}
  canActivate():boolean{
    if(this.service.loggedIn()){
      return true;

    }
    alert("You have not logged in!!!");
   
      this.router.navigate(['/login']);
      return false;
    

  }
  
}
