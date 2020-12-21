import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Order } from 'src/app/order/order';
import { OrderService } from 'src/app/services/order.service';

@Component({
  selector: 'app-customer-orders',
  templateUrl: './customer-orders.component.html',
  styleUrls: ['./customer-orders.component.css']
})
export class CustomerOrdersComponent implements OnInit {

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
  }

}
