import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { RegisterUser } from './registerUser';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  providers: [AuthService]
})
export class RegisterComponent implements OnInit {

  constructor(private authService: AuthService) { }
  user: RegisterUser = new RegisterUser();

  cevap: String;
  sorular: String[] = ["  İlkokuldaki İlk Öğretmeninizin Adı?", "İlk sahip olduğunuz evcil hayvan Adı?"]
  ngOnInit(): void {
  }

  register(user: RegisterUser) {
    console.log(user.email)
    console.log(user.sifre)
    this.authService.register(user)
  }
}
