import { LoginService } from './../Shared/login.service';
import { Login } from './../Shared/login';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
Role:string;
login:Login;
  constructor(
    private loginservice: LoginService,
    private toastr: ToastrService,
    private router:Router
  ) { }
  ngOnInit(): void {
    this.resetForm();
  }

  resetForm(form?: NgForm) {
    if (form != null) form.reset();
    this.login = {
      EmailID: '',
      Password: ''
    
    
    };
  }

  OnSubmit(form: NgForm) {
   // console.log(form.value);
    if(form.value.role=='Doctor'){
    this.loginservice.userlogin(form.value).subscribe(
      (data: any) => {  
        localStorage.setItem('token',data.token);
        //localStorage.setItem('items',form.value);
  
        localStorage.setItem('Id',form.value.EmailID)
        this.router.navigateByUrl('/user');

      });
    }else if(form.value.role=='Admin'){
      this.loginservice.Adminlogin(form.value).subscribe(
        (data: any) => {  
          localStorage.setItem('token',data.token);
        
          this.router.navigateByUrl('/admin');
  
        });

}
this.toastr.success("Logined in Successfully!!")
}
}
