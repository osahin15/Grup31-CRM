import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Product } from '../product/product';
import { Observable, throwError } from 'rxjs';
import { tap, catchError } from 'rxjs/operators'
import { Customer } from '../customer/customer';


@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  readonly APIUrl = "https://localhost:5001/api/bayi"
  constructor(private http: HttpClient) { }


  getCustomers(userId): Observable<Customer[]> {
    return this.http.get<Customer[]>(this.APIUrl + '/getlist').pipe(
      tap(data => console.log(JSON.stringify(data))),
      catchError(this.handleError)
    )
  }

  addCustomer(customer: Customer): Observable<Customer> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': 'Token'
      })
    }
    return this.http.post<Customer>(this.APIUrl, customer, httpOptions).pipe(
      tap(data => console.log(JSON.stringify(data))),
      catchError(this.handleError)
    )
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
