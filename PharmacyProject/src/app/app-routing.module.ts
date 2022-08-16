import { DocRoleGuard } from './auth/doc-role.guard';
import { RoleGuard } from './auth/role.guard';
import { SalesComponent } from './sales/sales.component';
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
  {path:"user",component:UserdashboardComponent,canActivate:[AuthGuard,DocRoleGuard]},
  {path:"admin",component:AdmindashboardComponent,canActivate:[RoleGuard,AuthGuard]},
  {path:"supplier",component:SupplierComponent,canActivate:[AuthGuard,RoleGuard]},
  {path:"admindrug",component:AdmindrugsComponent,canActivate:[AuthGuard,RoleGuard]},
  {path:"adminorders",component:OrderdetailsComponent,canActivate:[AuthGuard,RoleGuard]},
  {path:"cart",component:CartComponent,canActivate:[AuthGuard,DocRoleGuard]},
  {path:"sales",component:SalesComponent,canActivate:[AuthGuard,RoleGuard]},
  {path:"**",component:HomeComponent,canActivate:[AuthGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
