
import { HttpError } from './Shared/http-error';
import { PharmacyServiceService } from './Shared/pharmacy-service.service';
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
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { DoctorSignUpService } from './Shared/doctor-sign-up.service';
import { ToastrModule } from 'ngx-toastr';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { CartComponent } from './cart/cart.component';
import { SalesComponent } from './sales/sales.component';


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
    OrderdetailsComponent,
    CartComponent,
    SalesComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    Ng2SearchPipeModule
    
  ],
  providers: [DoctorSignUpService,LoginService,PharmacyServiceService,AuthGuard
    ,/* {
      provide:HTTP_INTERCEPTORS,
      useClass:ErrorHandel,
      multi:true 
  } */],
  bootstrap: [AppComponent]
})
export class AppModule { }
