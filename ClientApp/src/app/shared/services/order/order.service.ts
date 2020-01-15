import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { OrderModel } from 'src/app/shared/models/order/OrderModel';
import { environment } from 'src/environments/environment';
import { OrderFilterModel } from 'src/app/shared/models/order/OrderFilterModel';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  constructor( private http: HttpClient) { }

  getOrders(orderFilter: OrderFilterModel): Observable<OrderModel> {
    return this.http.post<OrderModel>( environment.baseUrl + 'order/getOrders',orderFilter)
  }
}
