import { Component, OnInit, Input } from '@angular/core';
import { NgForm } from '@angular/forms';
import { CustomerService } from 'src/app/services/customer.service';
import { Customer } from '../customer';

@Component({
  selector: 'app-edit-customer',
  templateUrl: './edit-customer.component.html',
  styleUrls: ['./edit-customer.component.css']
})
export class EditCustomerComponent implements OnInit {

  constructor(private customerService: CustomerService) { }
  @Input() cus: Customer;

  model: Customer = new Customer();

  ngOnInit(): void {
    this.model.bayiAd = this.cus.bayiAd;
    this.model.bayiId = this.cus.bayiId;
    this.model.bayiAdres = this.cus.bayiAdres;
    this.model.bayiMail = this.cus.bayiMail;
  }
  updateCustomer(form: NgForm) {
    var val = {
      bayiId: this.model.bayiId,
      bayiAd: this.model.bayiAd,
      bayiAdres: this.model.bayiAdres,
      bayiMail: this.model.bayiMail
    };
    this.customerService.updateCustomer(val).subscribe(res => {
      alert(res.toString());
    })
  }

}
