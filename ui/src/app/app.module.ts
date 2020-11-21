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

@NgModule({
  declarations: [
    AppComponent,
    CustomerComponent,
    ProductComponent,
    LoginComponent,
    ProductAddComponent,
    CustomerAddComponent,
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
