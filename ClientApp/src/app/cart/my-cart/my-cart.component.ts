import { Component, OnInit, Inject } from '@angular/core';
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
import { OrderStatusType } from 'src/app/shared/enums/OrderStatusType';
import { OrderModel } from 'src/app/shared/models/order/OrderModel';

@Component({
  selector: 'app-my-cart',
  templateUrl: './my-cart.component.html',
  styleUrls: ['./my-cart.component.css']
})
export class MyCartComponent implements OnInit {

  displayedColumns: string[]; 
  dataSource:OrderModelItem;
  orderModelItem: OrderModelItem;
  localStorage: Storage;
  orderItemModelItem: OrderItemModelItem;
  baseModel: BaseModel;
  amount = Filter.zero;
  orderFilter: OrderFilterModel;
  itemsCount: number;
  items: Array<OrderModelItem>;
  
  constructor(@Inject(MAT_DIALOG_DATA) public data: OrderModelItem, private orderService: OrderService, private dialog: MatDialog, private stripeService: StripeService,) { 
    
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
    this.getOrders();
    this.items.push(this.data);
    this.stripeService.loadStripe();
  }

  getOrders() {
    this.orderService.getUserOrders(this.orderFilter).subscribe(data => {
      this.itemsCount = data.itemsCount;
      this.items = data.items;
    })
  }

  


  create() {
    this.orderModelItem = this.data;
    this.orderModelItem.amountOrder = this.amount;
    this.orderService.createOrder(this.orderModelItem).subscribe(data => {
      debugger;
        this.baseModel.errors = data.errors
        if(this.baseModel.errors.length>0){
         this.dialog.open(ErrorComponent,{data:this.baseModel.errors})
        }
    })

    this.stripeService.pay(this.amount);
  }


  private totalAmount(items: Array<OrderItemModelItem>): number {
    
    items.forEach(element => {
      this.amount = this.amount + element.amount;
    });
    return this.amount;
  }
}
