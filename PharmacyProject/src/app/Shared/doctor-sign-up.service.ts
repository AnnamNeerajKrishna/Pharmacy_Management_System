import { Doctor } from './doctor';
import { Injectable } from '@angular/core';
import {HttpClient}from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DoctorSignUpService {

  readonly rootUrl = 'https://localhost:44348';
  
  constructor(private http:HttpClient){}

  registerdoctor(doctor : Doctor){
    const body: Doctor = {
      DoctorId:doctor.DoctorId,
      DoctorName: doctor.DoctorName,
      Password: doctor.Password,
      EmailID: doctor.EmailID,
      Contact:doctor.Contact,
      Address: doctor.Address
    }
    return this.http.post(this.rootUrl + '/api/Doctors/DoctorRegistration', body);
  }
}
