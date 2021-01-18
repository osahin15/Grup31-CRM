import { Component, OnInit } from '@angular/core';
import { RegisterUser } from '../register/registerUser';

@Component({
  selector: 'app-forgotpassword',
  templateUrl: './forgotpassword.component.html',
  styleUrls: ['./forgotpassword.component.css']
})
export class ForgotpasswordComponent implements OnInit {

  constructor() { }

  user: RegisterUser = new RegisterUser();



  ngOnInit(): void {

  }



  cevap: String;
  sorular: String[] = ["  İlkokuldaki İlk Öğretmeninizin Adı?", "İlk sahip olduğunuz evcil hayvan Adı?"]

}
