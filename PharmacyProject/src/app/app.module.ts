import { DocRoleGuard } from './auth/doc-role.guard';
import { RoleGuard } from './auth/role.guard';

import { HttpError } from './Shared/http-error';
import { PharmacyServiceService } from './Shared/pharmacy-service.service';
import { AuthGuard } from './auth/auth.guard';
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
import { TokenInterceptorService } from './Shared/token-interceptor.service';


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
  providers: [{
      provide:HTTP_INTERCEPTORS,
      useClass:TokenInterceptorService,
      multi:true 
  } ,
  DoctorSignUpService,LoginService,PharmacyServiceService,AuthGuard,RoleGuard,DocRoleGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
