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

  selectedCustomerId = 0;
  selectedProductId = 0;

  model: Order = new Order();
  customers: Customer[] = []
  products: Product[] = []
  ngOnInit(): void {
    this.refreshProList()
  }


  selected() {

    this.model.siparisId = this.selectedCustomerId
    this.model.urunId = this.selectedProductId
    console.log(this.model.urunId)
    console.log(this.model.siparisId)
  }

  refreshProList() {
    this.productService.getProductList().subscribe((data: any[]) => {
      console.log((data))
      this.products = data;
    });
    this.customerservice.getCustomerList().subscribe((data: any[]) => {
      console.log((data))
      this.customers = data;
    })
  }





  add(form: NgForm) {
    this.orderService.addOrder(this.model).subscribe(data => {
      alert(data.toString + "  eklendi.")
    })
  }
}
