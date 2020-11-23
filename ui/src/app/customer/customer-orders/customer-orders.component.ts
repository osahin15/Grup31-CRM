import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CustomerService } from 'src/app/services/customer.service';
import { Customer } from '../customer';

@Component({
  selector: 'app-customer-orders',
  templateUrl: './customer-orders.component.html',
  styleUrls: ['./customer-orders.component.css']
})
export class CustomerOrdersComponent implements OnInit {

  constructor(private customerservice:CustomerService,private activatedRoute: ActivatedRoute) { }
  customer: Customer = new Customer();
  customers: Customer[];

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      this.customerservice.getCustomers(params["userId"]).subscribe(data => {
        this.customers = data
      })
    })
  }

}
