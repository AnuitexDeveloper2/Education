import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MyCartComponent } from 'src/app/cart/my-cart/my-cart.component';
import { PayPageComponent } from 'src/app/cart/pay-page/pay-page.component';


const routes: Routes = [
  {path: 'my-cart', component: MyCartComponent},
  {path: 'pay-page', component: PayPageComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CartRoutingModule { }
