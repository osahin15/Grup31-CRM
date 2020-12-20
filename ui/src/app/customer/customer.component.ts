<<<<<<< HEAD
import { Component, Input, OnInit, Output } from '@angular/core';
=======
import { Component, Input, OnInit } from '@angular/core';
>>>>>>> bf1f7ef5ee73e23d37af0ff6269efda19f4bbb0d
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { CustomerService } from '../services/customer.service';
import { Customer } from './customer';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css'],
  providers: [CustomerService]
})
export class CustomerComponent implements OnInit {

  constructor(private customerservice: CustomerService, private activatedRoute: ActivatedRoute) { }
  customer: Customer = new Customer();
  customers: Customer[]

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      this.customerservice.getCustomers(params["userId"]).subscribe(data => {
        this.customers = data
      })
    })
  }
<<<<<<< HEAD
  
  @Input() name:string;
=======
  @Input() name: string;
>>>>>>> bf1f7ef5ee73e23d37af0ff6269efda19f4bbb0d
  display = false;
  onPressCallCustomerOrder(name: string) {
    this.display = !this.display;
    this.name = name;
  }

}
