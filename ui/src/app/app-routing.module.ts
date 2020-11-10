import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CustomerAddComponent } from './customer/customer-add/customer-add.component';
import { CustomerComponent } from './customer/customer.component';
import { LoginComponent } from './login/login.component';
import { LoginGuard } from './login/login.guard';
import { ProductAddComponent } from './product/product-add/product-add.component';
import { ProductComponent } from './product/product.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'customers', component: CustomerComponent, canActivate: [LoginGuard] },
  { path: 'products', component: ProductComponent, canActivate: [LoginGuard] },
  { path: 'product-add', component: ProductAddComponent },
  { path: 'customer-add', component: CustomerAddComponent, canActivate:[LoginGuard]},
  { path: '', redirectTo: 'login', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
