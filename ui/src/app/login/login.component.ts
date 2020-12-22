import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { RegisterComponent } from '../register/register.component';
import { AuthService } from '../services/auth.service';
import { User } from './user';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers: [AuthService]
})
export class LoginComponent implements OnInit {

  constructor(private authService: AuthService, private router: Router) { }
  user: User = new User();
  ActivateEditComp: boolean = false;
  ngOnInit(): void {
  }
  login(user: User) {
    this.authService.login(user)
  }

  isLoggedIn(): boolean {
    return this.authService.isAuthenticated
  }
  registerClick() {
    this.ActivateEditComp = true;
  }

  closeClick() {
    this.ActivateEditComp = false;
  }

}
