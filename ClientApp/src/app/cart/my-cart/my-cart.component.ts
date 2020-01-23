import { Component, OnInit, Inject, Predicate } from '@angular/core';
import { OrderModelItem } from 'src/app/shared/models/order/OrderModelItem';
import { OrderItemModelItem } from 'src/app/shared/models/orderItem/orderItemModelItem';
import { MAT_DIALOG_DATA, MatDialog } from '@angular/material';
import { OrderService } from 'src/app/shared/services/order/order.service';
import { ColumnName } from 'src/app/shared/constants/column-name';
import { OrderItemModel } from 'src/app/shared/models/orderItem/orderItemModel';
import { BaseModel } from 'src/app/shared/models/Base/BaseModel';
import { ErrorComponent } from 'src/app/shared/components/error/error.component';
import { Filter } from 'src/app/shared/constants/Filter';
import { StripeService } from 'src/app/shared/services/stripe/stripe.service';
import { OrderFilterModel } from 'src/app/shared/models/order/OrderFilterModel';
import { LocalStorage } from 'src/app/shared/services/localStorage/localStorage';

@Component({
  selector: 'app-my-cart',
  templateUrl: './my-cart.component.html',
  styleUrls: ['./my-cart.component.css'],
  providers: [LocalStorage]
})
export class MyCartComponent implements OnInit {

  displayedColumns: string[]; 
  dataSource: OrderModelItem;
  orderModelItem: OrderModelItem;
  orderItemModelItem: OrderItemModelItem;
  baseModel: BaseModel;
  amount = Filter.zero;
  orderFilter: OrderFilterModel;
  itemsCount: number;
  items: Array<OrderModelItem>;
  callbeckUrl: Predicate<string>;
 
  constructor(@Inject(MAT_DIALOG_DATA) public data: OrderModelItem, private orderService: OrderService, private dialog: MatDialog, private stripeService: StripeService, private localStorage:LocalStorage) { 
    this.dataSource = data;
    this.orderFilter = new OrderFilterModel();
    this.baseModel = new BaseModel();
    this.amount = this.totalAmount(this.data.orderItems.items);
    this.displayedColumns = [ColumnName.Product, ColumnName.UnitPrice, ColumnName.Qty, ColumnName.OrderAmount];
    this.orderModelItem = new OrderModelItem();
    this.orderItemModelItem = new OrderItemModelItem();
    this.orderModelItem.orderItems = new OrderItemModel();
    this.items = new Array<OrderModelItem>();
  }

  ngOnInit() {
    this.orderFilter.pageNumber = Filter.one;
    this.orderFilter.pageSize = Filter.ten;
    this.orderFilter.statusOrder = [Filter.zero];
    this.items.push(this.data);
    this.stripeService.loadStripe();
  }

  create() {
    let user = this.localStorage.getUser();
    this.orderModelItem = this.data;
    this.orderModelItem.amountOrder = this.amount;
    this.orderModelItem.userId = user.id;
    this.orderService.createOrder(this.orderModelItem).subscribe(data => {
        this.baseModel.errors = data.errors
        if(this.baseModel.errors.length > 0) {
         this.dialog.open(ErrorComponent,{data:this.baseModel.errors})
        }
    })

    this.stripeService.pay(this.amount);
    debugger;
    let TransactionId = this.localStorage.getTransactionId();
  }

  private totalAmount(items: Array<OrderItemModelItem>): number {
    items.forEach(element => {
      this.amount = this.amount + element.amount;
    });
    return this.amount;
  }

  deleteItem(element: OrderItemModelItem) {
    debugger;
    let index: number = 0;
    let item = element;
      for (let i = 0; i < this.dataSource.orderItems.items.length; i++) {
      
        if (item === this.dataSource.orderItems.items[i]) {
          index = i;
        }
      }
      this.localStorage.removeItemFromCart(index);
      this.dataSource.orderItems.items = this.localStorage.getCart();
  }


}
