<<<<<<< HEAD
import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Order } from 'src/app/order/order';
import { OrderService } from 'src/app/services/order.service';
=======
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CustomerService } from 'src/app/services/customer.service';
import { Customer } from '../customer';
>>>>>>> 038c65c57bc35d726acdc2fc95beb75ec9445e96

@Component({
  selector: 'app-customer-orders',
  templateUrl: './customer-orders.component.html',
  styleUrls: ['./customer-orders.component.css']
})
export class CustomerOrdersComponent implements OnInit {

<<<<<<< HEAD
  customerOrder: Order = new Order();
  customerOrders : Order[];


  constructor(private orderService: OrderService, private activatedRoute: ActivatedRoute) { }

  @Input() name:string;

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      this.orderService.getOrders(params["userId"]).subscribe(data => {
        this.customerOrders = data
=======
  constructor(private customerservice:CustomerService,private activatedRoute: ActivatedRoute) { }
  customer: Customer = new Customer();
  customers: Customer[];

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      this.customerservice.getCustomers(params["userId"]).subscribe(data => {
        this.customers = data
>>>>>>> 038c65c57bc35d726acdc2fc95beb75ec9445e96
      })
    })
  }

}
