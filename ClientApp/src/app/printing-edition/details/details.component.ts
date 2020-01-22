import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { PrintingEditionModelItem } from 'src/app/shared/models/printing-editions/PrintingEditionModelItem';
import { PrintingEditionService } from 'src/app/shared/services/printingEdition/printing-edition.service';
import { Filter } from 'src/app/shared/constants/Filter';
import { OrderModelItem } from 'src/app/shared/models/order/OrderModelItem';
import { OrderItemModelItem } from 'src/app/shared/models/orderItem/orderItemModelItem';
import { MyCartComponent } from 'src/app/cart/my-cart/my-cart.component';
import { OrderItemModel } from 'src/app/shared/models/orderItem/orderItemModel';
import { LocalStorage } from 'src/app/shared/services/localStorage/localStorage';
import { UserModelItem } from 'src/app/shared/models/user/UserModelItem';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css'],
  providers: [LocalStorage]
})
export class DetailsComponent implements OnInit {
 
  amountList: number[];
  printingEdition: PrintingEditionModelItem;
  amount: number;
  orderModelItem: OrderModelItem;
  orderItemModelItem: OrderItemModelItem;
  user: UserModelItem;
  constructor(private service: PrintingEditionService, private dialog: MatDialog, private localStorage: LocalStorage) {
    this.checkCurrentState();
    this.user = localStorage.getUser();
    this.printingEdition = new PrintingEditionModelItem();
    this.amountList = [Filter.one,Filter.two,Filter.three,Filter.four];
    this.amount = this.printingEdition.price;
    this.orderModelItem = new OrderModelItem();
    this.orderItemModelItem = new OrderItemModelItem();
    this.orderModelItem.orderItems = new OrderItemModel();
    this.orderModelItem.orderItems.items = new Array<OrderItemModelItem>();
  }
  
  
  ngOnInit() {
    debugger;
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
    this.localStorage.setCart(this.orderItemModelItem)
    this.orderModelItem.orderItems.items = this.localStorage.getCart();
    let dialogRef = this.dialog.open(MyCartComponent,{data:this.orderModelItem}).afterClosed().subscribe();
  }

  quantity(qty: number) {
    this.amount = this.printingEdition.price * qty;
  }

  checkCurrentState() {
    this.printingEdition = this.service.printingEdition;
    if ( this.printingEdition  == null) {
      location.href = 'http://localhost:4200/books/main';
    }
  }
}
