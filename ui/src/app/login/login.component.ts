import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { RegisterComponent } from '../register/register.component';
import { AccountService } from '../services/account.service';
import { User } from './user';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private accountService: AccountService, private router: Router) { }
  model: User = new User();

  ngOnInit(): void {
  }
  login(form: NgForm) {
    this.accountService.login(this.model);
  }

  register() {
    this.router.navigate(['/register'])
  }

}
