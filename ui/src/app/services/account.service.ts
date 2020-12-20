import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../login/user';

@Injectable()
export class AccountService {

  constructor(private http: HttpClient) { }
  loggedIn = false;
  login(user: User): boolean {
    if (user.email == "onur" && user.sifre == "123456") {

      this.loggedIn = true;
      localStorage.setItem("isLogged", user.email)
      return true;
    }
    return false;
  }
  isLoggedIn() {
    return this.loggedIn
  }
  logOut() {
    localStorage.removeItem("isLogged")
    this.loggedIn = false
  }



}
