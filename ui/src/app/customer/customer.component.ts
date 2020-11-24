<<<<<<< HEAD
import { Component, Input, OnInit, Output } from '@angular/core';
=======
import { Component, Input, OnInit} from '@angular/core';
>>>>>>> 038c65c57bc35d726acdc2fc95beb75ec9445e96
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
  @Input() name:string;
  display = false;
  onPressCallCustomerOrder(name:string){
    this.display = !this.display;
    this.name = name;
  }

}
