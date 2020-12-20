import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Customer } from '../customer/customer';
import { Product } from '../product/product';
import { CustomerService } from '../services/customer.service';
import { OrderService } from '../services/order.service';
import { ProductService } from '../services/product.service';
import { Order } from './order';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css'],
  providers: [OrderService]
})
export class OrderComponent implements OnInit {

  constructor(private orderService: OrderService, private activatedRoute: ActivatedRoute, private customerservice: CustomerService
    , private productService: ProductService) { }
  selectedCustomer = "Seçiniz..";
  selectedProduct = "Seçiniz..";

  model: Order = new Order();
  customers: Customer[] = []
  products: Product[] = []
  ngOnInit(): void {

  }

  selected() {
    this.model.customerName = this.selectedCustomer
    this.model.product = this.selectedProduct
    console.log(this.model.customerName)
  }





  add(form: NgForm) {
    this.orderService.addOrder(this.model).subscribe(data => {
      alert(data.description + "  eklendi.")
    })
  }
}
