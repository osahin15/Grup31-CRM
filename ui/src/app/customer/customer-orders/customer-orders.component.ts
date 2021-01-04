import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Order } from 'src/app/order/order';
import { CustomerService } from 'src/app/services/customer.service';
import { OrderService } from 'src/app/services/order.service';
import { Customer } from '../customer';

@Component({
  selector: 'app-customer-orders',
  templateUrl: './customer-orders.component.html',
  styleUrls: ['./customer-orders.component.css']
})
export class CustomerOrdersComponent implements OnInit {

<<<<<<< HEAD
  constructor(private customerservice: CustomerService, private activatedRoute: ActivatedRoute) { }
  customer: Customer = new Customer();
  customers: Customer[];

  ngOnInit(): void {

=======
  customerOrder: Order = new Order();
  customerOrders: Order[];


  constructor(private orderService: OrderService, private activatedRoute: ActivatedRoute) { }

  @Input() name: string;

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      this.orderService.getOrders(params["userId"]).subscribe(data => {
        this.customerOrders = data
      })
    })
>>>>>>> master
  }

}
