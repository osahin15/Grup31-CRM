import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Product } from '../product/product';
import { Observable, throwError } from 'rxjs';
import { tap, catchError } from 'rxjs/operators'


@Injectable({
  providedIn: 'root'
})
export class ProductService {

  readonly APIUrl = "https://localhost:5001/api/urun"

  constructor(private http: HttpClient) { }






  getProductList(): Observable<any[]> {
    return this.http.get<any[]>(this.APIUrl + '/getlist').pipe(
      tap(result => console.log(JSON.stringify(result))),
      catchError(this.handleError));
  }

  addProduct(val: Product) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': 'Token'
      })
    }
    return this.http.post(this.APIUrl + '/addurun', val, httpOptions)
  }

  updateProduct(val: Product) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': 'Token'
      })
    }
    return this.http.put(this.APIUrl + '/updateurun/' + val.urunId, val, httpOptions).pipe(
      tap(result => console.log(result)),
      catchError(this.handleError)
    );
  }

  deleteProduct(val: any) {
    return this.http.delete(this.APIUrl + '/deleteurun/' + val)
  }

  getProductById(val: any) {
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
