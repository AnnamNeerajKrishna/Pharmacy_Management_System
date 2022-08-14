import { Login } from './login';
import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  readonly rootUrl = 'https://localhost:44348';
  
  constructor(private http:HttpClient){}

  userlogin(login : Login)
  {
    const body: Login = {
      EmailID: login.EmailID,
      Password: login.Password      
    }
    return this.http.post(this.rootUrl 
      + '/api/DoctorLogin', body)    
  }
  Adminlogin(login : Login)
  {
    const body: Login = {
      EmailID: login.EmailID,
      Password: login.Password      
    }
    return this.http.post(this.rootUrl + '/api/AdminLogin', body);
  }
  loggedIn()
  {
    return !!localStorage.getItem('token');
  }
  /* grtToken(){
    return localStorage.getItem('token')
  } */
}
