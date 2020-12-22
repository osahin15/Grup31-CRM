import { Component, OnInit } from '@angular/core';
import { User } from '../login/user';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  providers: [AuthService]
})
export class RegisterComponent implements OnInit {

  constructor(private authService: AuthService) { }

  ngOnInit(): void {
  }

  register(user: User) {
    this.authService.register(user)
  }
}
