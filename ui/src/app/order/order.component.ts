import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Customer } from '../customer/customer';
import { CustomerService } from '../services/customer.service';
import { OrderService } from '../services/order.service';
import { Order } from './order';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css'],
  providers: [OrderService]
})
export class OrderComponent implements OnInit {

  constructor(private orderService: OrderService, private activatedRoute: ActivatedRoute, private customerservice: CustomerService) { }

  model: Order = new Order();
  customers: Customer[]
  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      this.customerservice.getCustomers(params["userId"]).subscribe(data => {
        this.customers = data
      })
    })
  }




  add(form: NgForm) {
    this.orderService.addOrder(this.model).subscribe(data => {
      this.model.customerName = "Customer1"
      alert(data.adet + "eklendi.")
    })
  }
}
