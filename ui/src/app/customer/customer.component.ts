import { Component, Input, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { CustomerService } from '../services/customer.service';
import { Customer } from './customer';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css'],
  providers: [CustomerService]
})
export class CustomerComponent implements OnInit {

  constructor(private customerService: CustomerService, private activatedRoute: ActivatedRoute) { }
  customer: Customer = new Customer();
  customers: Customer[]

  ModalTitle: String;
  filterText: string;
  ActivatedEditComp: boolean = false;
  cus: Customer;
  CustomerList: any = [];

  ngOnInit(): void {
    this.refreshCustomerList();
  }

  editClick(customer) {
    this.cus = customer
    this.ModalTitle = "Bayi Güncelle";
    this.ActivatedEditComp = true;
  }

  closeClick() {
    this.ActivatedEditComp = false;
    this.refreshCustomerList();
  }

  deleteClick(customer) {
    if (confirm("Silmek istedigine emin misin?")) {
      this.customerService.deleteCustomer(customer.bayiId).subscribe(data => {
        alert(data.toString());
        this.refreshCustomerList();
      })
    }
  }

  refreshCustomerList() {
    this.customerService.getCustomerList().subscribe((data: any[]) => {
      console.log((data))
      this.customers = data;
    });
  }
}
