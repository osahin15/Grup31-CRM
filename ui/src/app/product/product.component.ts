import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Customer } from '../customer/customer';
import { CustomerService } from '../services/customer.service';
import { OrderService } from '../services/order.service';
import { ProductService } from '../services/product.service';
import { Order } from '../order/order';
import { Product } from './product';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css'],
  providers: [ProductService, CustomerService, OrderService]
})
export class ProductComponent implements OnInit {

  constructor(private productService: ProductService, private activatedRoute: ActivatedRoute, private customerService: CustomerService) { }
  products: Product[]
  customer: Customer = new Customer();
  customers: Customer[]
  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      this.productService.getProducts(params["userId"]).subscribe(data => {
        this.products = data
      })
    })
  }



}
