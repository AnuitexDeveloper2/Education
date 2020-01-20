import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CartRoutingModule } from 'src/app/cart/cart-routing.module';
import { MyCartComponent } from 'src/app/cart/my-cart/my-cart.component';
import { MaterialModule } from 'src/app/material/material.module';
import { PayPageComponent } from './pay-page/pay-page.component';


@NgModule({
  declarations: [MyCartComponent, PayPageComponent],
  imports: [
    CommonModule,
    CartRoutingModule,
    MaterialModule
  ]
})
export class CartModule { }
