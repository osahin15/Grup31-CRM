import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Customer } from '../customer';

@Component({
  selector: 'app-customer-add',
  templateUrl: './customer-add.component.html',
  styleUrls: ['./customer-add.component.css']
})
export class CustomerAddComponent implements OnInit {

  customer: Customer = new Customer();

  add(form: NgForm){

  }

  constructor() { }

  ngOnInit(): void {
  }
}
