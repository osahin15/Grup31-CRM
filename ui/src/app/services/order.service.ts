import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { Order } from '../order/order';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  constructor(private http: HttpClient) { }
  readonly APIUrl = "https://localhost:5001/api/siparisdetay"


  getOrders(): Observable<Order[]> {
    /*let newPath = this.path;
    if (userId) {
      newPath += "?userId=" + userId
    }*/

    return this.http.get<any[]>(this.APIUrl + '/getlist').pipe(
      tap(result => console.log(JSON.stringify(result))),
      catchError(this.handleError));
  }

  addOrder(val: Order) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': 'Token'
      })
    }
    return this.http.post(this.APIUrl + '/addsiparisdetay', val, httpOptions)
  }
  updateOrder(val: Order) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': 'Token'
      })
    }
    return this.http.put(this.APIUrl + '/updatesiparisdetay/' + val.siparisDetayId, val, httpOptions).pipe(
      tap(result => console.log(result)),
      catchError(this.handleError)
    );
  }
  deleteProduct(val: any) {
    return this.http.delete(this.APIUrl + '/deletesiparisdetay/' + val)
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
