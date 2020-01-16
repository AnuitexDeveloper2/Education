import { Component, OnInit } from '@angular/core';
import { OrderService } from 'src/app/shared/services/order/order.service';
import { OrderFilterModel } from 'src/app/shared/models/order/OrderFilterModel';
import { OrderModelItem } from 'src/app/shared/models/order/OrderModelItem';
import { Filter } from 'src/app/shared/constants/Filter';
import { ColumnName } from 'src/app/shared/constants/column-name';
import { enumSelector } from 'src/app/Extention/EnumExtention';
import { OrderStatusType } from 'src/app/shared/enums/OrderStatusType';

@Component({
  selector: 'app-my-order',
  templateUrl: './my-order.component.html',
  styleUrls: ['./my-order.component.css']
})
export class MyOrderComponent implements OnInit {

  orderFilter: OrderFilterModel;
  items: Array<OrderModelItem>
  itemsCount: number;
  displayedColumns: string[];
  statusList: string[];
  constructor(private service: OrderService) {
    this.orderFilter = new OrderFilterModel();
    this.items = new Array<OrderModelItem>();
    this.displayedColumns = [ColumnName.Order,ColumnName.Date,ColumnName.Product,ColumnName.Title,ColumnName.Qty,ColumnName.OrderAmount,ColumnName.Status]
    this.statusList = enumSelector(OrderStatusType);

   }

  ngOnInit() {
    this.orderFilter.statusOrder = [Filter.zero,Filter.one];
    this.orderFilter.pageNumber = Filter.one;
    this.orderFilter.pageSize = Filter.ten;
    this.getOrders();
  }

  getOrders() {
    this.service.getUserOrders(this.orderFilter).subscribe(data => {
      this.itemsCount = data.itemsCount;
      this.items = data.items;
    })
  }

}
