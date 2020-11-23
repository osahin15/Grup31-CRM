import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CustomerAddComponent } from './customer/customer-add/customer-add.component';
import { CustomerOrdersComponent } from './customer/customer-orders/customer-orders.component';
import { CustomerComponent } from './customer/customer.component';
import { LoginComponent } from './login/login.component';
import { LoginGuard } from './login/login.guard';
import { OrderComponent } from './order/order.component';
import { ProductAddComponent } from './product/product-add/product-add.component';
import { ProductComponent } from './product/product.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  { path: '', component: LoginComponent, pathMatch: 'full' },
  { path: 'register', component: RegisterComponent },
  { path: 'customers', component: CustomerComponent },
  { path: 'products', component: ProductComponent },
  { path: 'product-add', component: ProductAddComponent },
  { path: 'customer-add', component: CustomerAddComponent },
  { path: 'order-add', component: OrderComponent },

<<<<<<< HEAD
  { path: 'customers', component: CustomerComponent },
  { path: 'products', component: ProductComponent /*, canActivate: [LoginGuard]*/ },
  { path: 'product-add', component: ProductAddComponent},
  { path: 'customer-add', component: CustomerAddComponent },
  { path: 'customer-orders', component: CustomerOrdersComponent },
=======
>>>>>>> af82cd885c6aee6497e7f22395b7f8da5d6145c7
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
