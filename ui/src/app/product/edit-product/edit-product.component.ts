import { Component, Input, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ProductService } from 'src/app/services/product.service';
import { Product } from '../product';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css']
})
export class EditProductComponent implements OnInit {

  constructor(private productService: ProductService) { }
  @Input() pro: Product;

  model: Product = new Product();

  ngOnInit(): void {
    this.model.urunAd = this.pro.urunAd;
    this.model.urunId = this.pro.urunId;
    this.model.urunFiyat = this.pro.urunFiyat;
    this.model.kategoriId = this.pro.kategoriId;
  }
  updateProduct(form: NgForm) {
    var val = {
      urunId: this.model.urunId,
      urunAd: this.model.urunAd,
      urunFiyat: this.model.urunFiyat,
      kategoriId: this.model.kategoriId
    };
    this.productService.updateProduct(val).subscribe(res => {
      alert(res.toString());
    })
  }

}
