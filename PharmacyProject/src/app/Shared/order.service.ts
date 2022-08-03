import { HttpClient } from '@angular/common/http';
import { Drugs } from './../Models/drugs';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Order } from '../Models/order';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  constructor(private http:HttpClient) { }
  readonly rootUrl = 'https://localhost:44348';
  GetOrders(): Observable<Order[]> {
    return this.http.get<Order[]>(this.rootUrl + '/api/Orders');
  }

  AddOrders(order: Order): Observable<Order> {
    return this.http.post<Order>(this.rootUrl + '/api/Orders', order);
  }

  DeleteOrder(id: number): Observable<Order> {
    return this.http.delete<Order>(
      this.rootUrl + '/api/Order/DeleteOrder/{id}' + id
    );
  }

  UpdateOrder(id: number, order: Order): Observable<Order> {
    return this.http.put<Order>(
      this.rootUrl + '/api/Order/EditOrder/{id}' + id,
      order
    );
  }
}
