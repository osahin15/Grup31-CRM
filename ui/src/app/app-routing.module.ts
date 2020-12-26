import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CustomerAddComponent } from './customer/customer-add/customer-add.component';
import { CustomerOrdersComponent } from './customer/customer-orders/customer-orders.component';
import { CustomerComponent } from './customer/customer.component';
import { LoginComponent } from './login/login.component';
import { LoginGuard } from './login/login.guard';
import { OrderComponent } from './order/order.component';
import { EditProductComponent } from './product/edit-product/edit-product.component';
import { ProductAddComponent } from './product/product-add/product-add.component';
import { ProductComponent } from './product/product.component';
import { RegisterComponent } from './register/register.component';
import { EditCustomerComponent } from './customer/edit-customer/edit-customer.component';

const routes: Routes = [
  { path: '', component: CustomerComponent, pathMatch: 'full', canActivate: [LoginGuard] },
  { path: 'login', component: LoginComponent },
  { path: 'customers', component: CustomerComponent, canActivate: [LoginGuard] },
  { path: 'products', component: ProductComponent, canActivate: [LoginGuard] },
  { path: 'product-add', component: ProductAddComponent, canActivate: [LoginGuard] },
  { path: 'customer-add', component: CustomerAddComponent, canActivate: [LoginGuard] },
  { path: 'order-add', component: OrderComponent, canActivate: [LoginGuard] },
  { path: 'customer-orders', component: CustomerOrdersComponent, canActivate: [LoginGuard] },

  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
