import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CustomerComponent } from './customer/customer.component';
import { ProductComponent } from './product/product.component';
import { LoginComponent } from './login/login.component';
import { ProductAddComponent } from './product/product-add/product-add.component';
import { LoginGuard } from './login/login.guard';
import { CustomerAddComponent } from './customer/customer-add/customer-add.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RegisterComponent } from './register/register.component';
import { OrderComponent } from './order/order.component';
import { CustomerOrdersComponent } from './customer/customer-orders/customer-orders.component';
import { EditProductComponent } from './product/edit-product/edit-product.component';
import { ProductFilterPipe } from './product/product-filter.pipe';
import { AuthInterceptorService } from './services/auth-interceptor.service';
import { AuthService } from './services/auth.service';
import { ForgotpasswordComponent } from './forgotpassword/forgotpassword.component';
import { EditCustomerComponent } from './customer/edit-customer/edit-customer.component';
import { CustomerFilterPipe } from './customer/customer-filter.pipe';



@NgModule({
  declarations: [
    AppComponent,
    CustomerComponent,
    ProductComponent,
    LoginComponent,
    ProductAddComponent,
    CustomerAddComponent,
    RegisterComponent,
    OrderComponent,
    CustomerOrdersComponent,
    EditProductComponent,
    ProductFilterPipe,
    CustomerFilterPipe,
    ForgotpasswordComponent,
    EditCustomerComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [AuthService, LoginGuard,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptorService,
      multi: true
    }],
  bootstrap: [AppComponent]
})
export class AppModule { }
