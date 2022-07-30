import { Router } from '@angular/router';
import { DoctorSignUpService } from './../Shared/doctor-sign-up.service';

import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Doctor } from '../Shared/doctor';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  doctor: Doctor;
  constructor(
    private doctorsignupservice: DoctorSignUpService,
    private toastr: ToastrService,
    private router:Router
  ) { }

  ngOnInit(): void {
    this.resetForm();
  }

  resetForm(form?: NgForm) {
    if (form != null) form.reset();
    this.doctor = {
      DoctorName: '',
      DoctorId: '',
      Password: '',
      EmailID: '',
      Contact: '',
      Address: '',
    };
  }

  OnSubmit(form: NgForm) {
    this.doctorsignupservice.registerdoctor(form.value).subscribe((data: any) => {
     console.log(form.value);
      if (data) {
        this.resetForm(form);
        this.toastr.success('User registration successful');
        this.router.navigateByUrl('/login');
      }
    });
  }
}
