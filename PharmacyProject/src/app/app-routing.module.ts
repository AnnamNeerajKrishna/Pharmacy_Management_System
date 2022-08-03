import { AuthGuard } from './auth/auth.guard';
import { NgModule } from '@angular/core';
import { RouterModule, Routes, CanActivate } from '@angular/router';
import { AboutComponent } from './about/about.component';
import { AdmindashboardComponent } from './admindashboard/admindashboard.component';
import { AdmindrugsComponent } from './admindrugs/admindrugs.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { OrderdetailsComponent } from './orderdetails/orderdetails.component';
import { SignupComponent } from './signup/signup.component';
import { SupplierComponent } from './supplier/supplier.component';
import { UserdashboardComponent } from './userdashboard/userdashboard.component';
import { CartComponent } from './cart/cart.component';  

const routes: Routes = [
  {path:"",component:HomeComponent},
  {path:"home",component:HomeComponent},
  {path:"about",component:AboutComponent},
  {path:"login",component:LoginComponent},
  {path:"signup",component:SignupComponent},
  {path:"user",component:UserdashboardComponent},
  {path:"admin",component:AdmindashboardComponent,canActivate:[AuthGuard]},
  {path:"supplier",component:SupplierComponent,canActivate:[AuthGuard]},
  {path:"admindrug",component:AdmindrugsComponent,canActivate:[AuthGuard]},
  {path:"adminorders",component:OrderdetailsComponent,canActivate:[AuthGuard]},
  {path:"cart",component:CartComponent},
  {path:"**",component:HomeComponent,canActivate:[AuthGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
