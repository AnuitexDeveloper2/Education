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

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {
 
  amountList: number[];
  printingEdition: PrintingEditionModelItem;
  amount: number;
  orderModel: OrderModelItem;
  orderItemModelItem: OrderItemModelItem;
  constructor(private service: PrintingEditionService, private dialog: MatDialog) {
    this.printingEdition = new PrintingEditionModelItem();
    this.amountList =[Filter.one,Filter.two,Filter.three,Filter.four];
    this.amount = this.printingEdition.price;
    this.orderModel = new OrderModelItem();
    this.orderItemModelItem = new OrderItemModelItem();
   }
  
  
  ngOnInit() {
     this.printingEdition = this.service.printingEdition;
     this.amount = this.printingEdition.price
  }

  purchase() {
    this.orderItemModelItem.printingEditionName = this.printingEdition.title;
    this.orderItemModelItem.printingEditionPrice = this.printingEdition.price;
    this.orderItemModelItem.count = this.amount/ this.printingEdition.price;
    this.orderItemModelItem.amount = this.amount;
    let dialogRef = this.dialog.open(CreateOrderComponent,{data:this.orderItemModelItem}).afterClosed().subscribe();
  }

  quantity(qty:number) {
    this.amount = this.printingEdition.price * qty;
  }
}
