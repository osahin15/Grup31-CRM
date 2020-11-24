import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CustomerComponent } from './customer/customer.component';
import { ProductComponent } from './product/product.component';
import { LoginComponent } from './login/login.component';
import { ProductAddComponent } from './product/product-add/product-add.component';
import { LoginGuard } from './login/login.guard';
import { AccountService } from './services/account.service';
import { CustomerAddComponent } from './customer/customer-add/customer-add.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RegisterComponent } from './register/register.component';
<<<<<<< HEAD
import { CustomerOrdersComponent } from './customer/customer-orders/customer-orders.component';
=======
import { OrderComponent } from './order/order.component';
import { CustomerOrdersComponent } from './customer/customer-orders/customer-orders.component';

>>>>>>> af82cd885c6aee6497e7f22395b7f8da5d6145c7


@NgModule({
  declarations: [
    AppComponent,
    CustomerComponent,
    ProductComponent,
    LoginComponent,
    ProductAddComponent,
    CustomerAddComponent,
    RegisterComponent,
<<<<<<< HEAD
    CustomerOrdersComponent,
=======
    OrderComponent,
<<<<<<< HEAD
    CustomerOrdersComponent,
=======
>>>>>>> af82cd885c6aee6497e7f22395b7f8da5d6145c7
>>>>>>> 038c65c57bc35d726acdc2fc95beb75ec9445e96
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [AccountService, LoginGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
