/* import { TokenInterceptorService } from './Shared/token-interceptor.service';
 */import { AuthGuard } from './auth/auth.guard';
import { LoginService } from './Shared/login.service';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { AboutComponent } from './about/about.component';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { UserdashboardComponent } from './userdashboard/userdashboard.component';
import { AdmindashboardComponent } from './admindashboard/admindashboard.component';
import { SupplierComponent } from './supplier/supplier.component';
import { AdmindrugsComponent } from './admindrugs/admindrugs.component';
import { OrderdetailsComponent } from './orderdetails/orderdetails.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { DoctorSignUpService } from './Shared/doctor-sign-up.service';
import { ToastrModule } from 'ngx-toastr';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AboutComponent,
    LoginComponent,
    SignupComponent,
    UserdashboardComponent,
    AdmindashboardComponent,
    SupplierComponent,
    AdmindrugsComponent,
    OrderdetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    
  ],
  providers: [DoctorSignUpService,LoginService,AuthGuard/*{
      provide:HTTP_INTERCEPTORS,
      useClass:TokenInterceptorService,
      multi:true 
  }*/],
  bootstrap: [AppComponent]
})
export class AppModule { }
