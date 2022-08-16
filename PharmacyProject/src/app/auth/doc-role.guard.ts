import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class DocRoleGuard implements CanActivate {
  constructor(private router:Router){}
  canActivate()
  {
    let Role=localStorage.getItem('UserType');

    if(Role=="Doctor"){
      return true;
    }
    alert("You don't have the access")
    this.router.navigate(['/login'])
   return false;
  }
  
}
