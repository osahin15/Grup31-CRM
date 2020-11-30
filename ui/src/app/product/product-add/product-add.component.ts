import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { User } from 'src/app/login/user';
import { ProductService } from 'src/app/services/product.service';
import { Product } from '../product';

@Component({
  selector: 'app-product-add',
  templateUrl: './product-add.component.html',
  styleUrls: ['./product-add.component.css']
})
export class ProductAddComponent implements OnInit {

  constructor(private productService: ProductService) { }
  model: Product = new Product();
  user: User = new User();
  ngOnInit(): void {
  }
  /* add(form: NgForm) {
     this.productService.addProduct(this.model).subscribe(data => {
       alert(data.name + "eklendi.")
     })
   }*/
}
