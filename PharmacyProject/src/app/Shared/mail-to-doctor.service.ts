import { Order } from './../Models/order';
import { Doctor } from './doctor';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MailToDoctorService {

  constructor(private http:HttpClient) { }
  readonly rootUrl = 'https://localhost:44348';

  SendMail(order:any){
    return this.http.post(this.rootUrl + '/api/Email/SendingEmail',order);
  }
  SendingMailByAdmin(order:any){
    return this.http.post(this.rootUrl + '/api/Email/SendingMailByAdmin',order);

  }


}

