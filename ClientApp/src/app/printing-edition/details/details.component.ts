import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { FormBuilder, FormGroup } from '@angular/forms';
import { PrintingEditionModelItem } from 'src/app/shared/models/printing-editions/PrintingEditionModelItem';
import { PrintingEditionService } from 'src/app/shared/services/printingEdition/printing-edition.service';
import { Filter } from 'src/app/shared/constants/Filter';
import { CreateOrderComponent } from 'src/app/order/create-order/create-order.component';
import { OrderModel } from 'src/app/shared/models/order/OrderModel';
import { OrderModelItem } from 'src/app/shared/models/order/OrderModelItem';
import { OrderItemModelItem } from 'src/app/shared/models/orderItem/orderItemModelItem';
import { MyCartComponent } from 'src/app/cart/my-cart/my-cart.component';
import { OrderItemModel } from 'src/app/shared/models/orderItem/orderItemModel';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {
 
  amountList: number[];
  printingEdition: PrintingEditionModelItem;
  amount: number;
  orderModelItem: OrderModelItem;
  orderItemModelItem: OrderItemModelItem;
  constructor(private service: PrintingEditionService, private dialog: MatDialog) {
    debugger;
    this.printingEdition = new PrintingEditionModelItem();
    this.amountList =[Filter.one,Filter.two,Filter.three,Filter.four];
    this.amount = this.printingEdition.price;
    this.orderModelItem = new OrderModelItem();
    this.orderItemModelItem = new OrderItemModelItem();
    this.orderModelItem.orderItems = new OrderItemModel();
    this.orderModelItem.orderItems.items = new Array<OrderItemModelItem>();
   }
  
  
  ngOnInit() {
     this.printingEdition = this.service.printingEdition;
     this.amount = this.printingEdition.price
  }

  purchase() {
    debugger;
    this.orderItemModelItem.printingEditionName = this.printingEdition.title;
    this.orderItemModelItem.printingEditionPrice = this.printingEdition.price;
    this.orderItemModelItem.printingEditionId = this.printingEdition.id;
    this.orderItemModelItem.count = this.amount / this.printingEdition.price;
    this.orderItemModelItem.amount = this.amount;
    this.orderModelItem.orderItems.items.push(this.orderItemModelItem);
    let dialogRef = this.dialog.open(MyCartComponent,{data:this.orderModelItem}).afterClosed().subscribe();
  }

  quantity(qty:number) {
    this.amount = this.printingEdition.price * qty;
  }
}
