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

  ModalTitle: String;

  ActivateEditComp: boolean = false;
  pro: Product;
  ProductList: any = [];

  ngOnInit(): void {
    this.refreshProList();
  }

  editClick(product) {
    this.pro = product
    this.ModalTitle = "Ürün Güncelle";
    this.ActivateEditComp = true;
  }

  closeClick() {
    this.ActivateEditComp = false;
    this.refreshProList();
  }

  deleteClick(product) {
    if (confirm("Silmek istedigine emin misin?")) {
      this.productService.deleteProduct(product.urunId).subscribe(data => {
        alert(data.toString());
        this.refreshProList();
      })
    }

  }
  refreshProList() {
    this.productService.getProductList().subscribe((data: any[]) => {
      console.log((data))
      this.products = data;
    });
  }



}
