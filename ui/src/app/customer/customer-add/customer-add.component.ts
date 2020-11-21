import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { CustomerService } from 'src/app/services/customer.service';
import { Customer } from '../customer';

@Component({
  selector: 'app-customer-add',
  templateUrl: './customer-add.component.html',
  styleUrls: ['./customer-add.component.css']
})
export class CustomerAddComponent implements OnInit {


  constructor(private customerService: CustomerService) { }
  customer: Customer = new Customer();
  add(form: NgForm) {
    this.customerService.addCustomer(this.customer).subscribe(data => {
      alert(data.customerName + " eklendi.")
    })
  }

  ngOnInit(): void {
  }
}
