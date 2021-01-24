import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Product } from '../product/product';
import { Observable, throwError } from 'rxjs';
import { tap, catchError } from 'rxjs/operators'
import { Customer } from '../customer/customer';
import { City } from '../customer/customer-add/city';


@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  readonly APIUrl = "https://localhost:5001/api/bayi"
  constructor(private http: HttpClient) { }

  cityApi = " http://localhost:3000/iller"

  getCity() {
    return this.http.get<City[]>(this.cityApi).pipe(
      tap(data => console.log(JSON.stringify(data))),
      catchError(this.handleError)
    )
  }

  getCustomerList(): Observable<Customer[]> {
    return this.http.get<Customer[]>(this.APIUrl + '/getlist').pipe(
      tap(data => console.log(JSON.stringify(data))),
      catchError(this.handleError)
    )
  }

  addCustomer(customer: Customer) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': 'Token'
      })
    }
    return this.http.post(this.APIUrl + '/addbayi', customer, httpOptions)
  }

  updateCustomer(val: Customer) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': 'Token'
      })
    }
    return this.http.put(this.APIUrl + '/updatebayi/' + val.bayiId, val, httpOptions).pipe(
      tap(result => console.log(result)),
      catchError(this.handleError)
    );
  }

  deleteCustomer(val: any) {
    return this.http.delete(this.APIUrl + '/deletebayi/' + val)
  }

  getCustomerById(val: any) {
    return this.http.get(this.APIUrl + '/getfindbyid/' + val)
  }

  handleError(err: HttpErrorResponse) {
    let errorMessage = ''
    if (err.error instanceof ErrorEvent) {
      errorMessage = 'Bir hata oluştu' + err.error.message
    } else {
      errorMessage = 'Sistemsel bir hata'
    }
    return throwError(errorMessage)
  }

}
