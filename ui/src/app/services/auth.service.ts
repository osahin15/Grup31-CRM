import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable, throwError } from 'rxjs';
import { tap, catchError } from 'rxjs/operators'
import { User } from '../login/user';
import { RegisterUser } from '../register/registerUser';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  TOKEN_KEY = "token"

  readonly APIUrl = "https://localhost:5001/api"

  register(user: RegisterUser) {
    let headers = new HttpHeaders()
    headers = headers.append("Content-Type", "application/json")
    return this.http.post(this.APIUrl + '/user/adduser', user, { headers: headers }).subscribe(data => {
      console.log(data)
    })
  }
  login(user: User) {
    let headers = new HttpHeaders()
    headers = headers.append("Content-Type", "application/json")
    return this.http.post(this.APIUrl + '/login/accesstoken', user, { headers: headers }).subscribe(data => {
      console.log(data)
      this.saveToken(data)
    })
  }

  saveToken(token) {
    localStorage.setItem(this.TOKEN_KEY, token)
  }

  logOut() {
    localStorage.removeItem(this.TOKEN_KEY)
  }

  get isAuthenticated() {
    return !!localStorage.getItem(this.TOKEN_KEY)
  }
  get token() {
    return localStorage.getItem(this.TOKEN_KEY)
  }

}
