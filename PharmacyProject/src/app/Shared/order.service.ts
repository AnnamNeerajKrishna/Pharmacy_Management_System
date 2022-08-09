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
/* 
Deleting Orders
  DeleteOrder(id: number): Observable<Order> {
    return this.http.delete<Order>(
      this.rootUrl + '/api/Orders/' + id
    );
  }
 */
  UpdateOrder( order : Order): Observable<Order> {
    return this.http.put<Order>(
      this.rootUrl + '/api/Orders/' + order.orderId, order
    );
  }
  QuantityChange(drug:Drugs):Observable<Drugs>{
    return this.http.put<Drugs>(
      this.rootUrl+'/api/Drugs/'+drug.drugId,drug
    );
  }
  GetDrug(drugId :any):Observable<Drugs>{
    return this.http.get<Drugs>(
      this.rootUrl+'/api/Drugs/'+drugId
    );

  }
 

}
