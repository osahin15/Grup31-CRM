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
>>>>>>> bf1f7ef5ee73e23d37af0ff6269efda19f4bbb0d

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
      })
    })
=======
  constructor(private customerservice: CustomerService, private activatedRoute: ActivatedRoute) { }
  customer: Customer = new Customer();
  customers: Customer[];

  ngOnInit(): void {

>>>>>>> bf1f7ef5ee73e23d37af0ff6269efda19f4bbb0d
  }

}
