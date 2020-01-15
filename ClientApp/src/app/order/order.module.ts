import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { OrderRoutingModule } from 'src/app/order/order-routing.module';
import { OrdersComponent } from 'src/app/order/orders/orders.component';
import { MyOrderComponent } from 'src/app/order/my-order/my-order.component';
import { MaterialModule } from 'src/app/material/material.module';


@NgModule({
  declarations: [OrdersComponent, MyOrderComponent],
  imports: [
    CommonModule,
    OrderRoutingModule,
    MaterialModule
  ]
})
export class OrderModule { }
