import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { OrderService } from 'src/app/shared/services/order/order.service';
import { OrderFilterModel } from 'src/app/shared/models/order/OrderFilterModel';
import { OrderModelItem } from 'src/app/shared/models/order/OrderModelItem';
import { Filter } from 'src/app/shared/constants/Filter';
import { ColumnName } from 'src/app/shared/constants/column-name';
import { enumSelector } from 'src/app/Extention/EnumExtention';
import { OrderStatusType } from 'src/app/shared/enums/OrderStatusType';
import { PayPageComponent } from 'src/app/cart/pay-page/pay-page.component';
import { Router } from '@angular/router';
import { StripeService } from 'src/app/shared/services/stripe/stripe.service';

@Component({
  selector: 'app-my-order',
  templateUrl: './my-order.component.html',
  styleUrls: ['./my-order.component.css']
})
export class MyOrderComponent implements OnInit {

  handler:any = null;
  orderFilter: OrderFilterModel;
  items: Array<OrderModelItem>
  itemsCount: number;
  displayedColumns: string[];
  statusList: string[];
  constructor(private orderService: OrderService, private dialog: MatDialog, private router: Router, private stripeservice: StripeService) {
    this.orderFilter = new OrderFilterModel();
    this.items = new Array<OrderModelItem>();
    this.displayedColumns = [ColumnName.Order,ColumnName.Date,ColumnName.Product,ColumnName.Title,ColumnName.Qty,ColumnName.OrderAmount,ColumnName.Status]
    this.statusList = enumSelector(OrderStatusType);

   }

  ngOnInit() {
    this.stripeservice.loadStripe();
    this.orderFilter.statusOrder = [Filter.zero,Filter.one];
    this.orderFilter.pageNumber = Filter.one;
    this.orderFilter.pageSize = Filter.ten;
    this.getOrders();
  }

  getOrders() {
    this.orderService.getUserOrders(this.orderFilter).subscribe(data => {
      this.itemsCount = data.itemsCount;
      this.items = data.items;
    })
  }

  movePayPage(amount) {
    this.stripeservice.pay(amount);
     }

}
