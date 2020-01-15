import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { OrdersComponent } from 'src/app/order/orders/orders.component';
import { MyOrderComponent } from 'src/app/order/my-order/my-order.component';


const routes: Routes = [
  { path:'orders', component: OrdersComponent },
  { path: 'my-order', component: MyOrderComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OrderRoutingModule { }
