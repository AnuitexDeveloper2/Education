import { Component, OnInit } from '@angular/core';
import { OrderService } from 'src/app/shared/services/order/order.service';
import { OrderFilterModel } from 'src/app/shared/models/order/OrderFilterModel';
import { OrderModelItem } from 'src/app/shared/models/order/OrderModelItem';
import { Filter } from 'src/app/shared/constants/Filter';
import { ColumnName } from 'src/app/shared/constants/column-name';
import { enumSelector } from 'src/app/Extention/EnumExtention';
import { OrderItemModelItem } from 'src/app/shared/models/orderItem/orderItemModelItem';
import { OrderStatusType } from 'src/app/shared/enums/OrderStatusType';
import { MatSort, PageEvent } from '@angular/material';
import { SortOrderType } from 'src/app/shared/enums/SortOrderType';
import { SortType } from 'src/app/shared/enums/SortType';
import { FormControl,ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit {

  displayedColumns: string[];
  orderFilter: OrderFilterModel;
  items: Array<OrderModelItem>;
  itemsCount: number;
  statusList: string[];
  status: FormControl;
  
  
  constructor(private service: OrderService) {
    this.orderFilter = new OrderFilterModel();
    this.items = new Array<OrderModelItem>();
    this.displayedColumns = [ColumnName.Order,ColumnName.Date,ColumnName.UserName,ColumnName.UserEmail,ColumnName.Product,ColumnName.Title,ColumnName.Qty,ColumnName.OrderAmount,ColumnName.Status]
    this.statusList = enumSelector(OrderStatusType);
    this.status = new FormControl();
  }

  ngOnInit() {
    this.orderFilter.statusOrder = [Filter.zero,Filter.one];
    this.orderFilter.pageNumber = Filter.one;
    this.orderFilter.pageSize = Filter.ten;
    this.getOrders();
    
  }
  getOrders() {
    debugger;
    return this.service.getOrders(this.orderFilter).subscribe(data => {
      this.itemsCount = data.itemsCount;
      this.items = data.items;
       });
    }

    sort(event: MatSort) {
      this.orderFilter.sortOrder = SortOrderType[event.active];
      this.orderFilter.sortType = SortType[event.direction];
      this.getOrders();
    }

    movePage(event: PageEvent) {
      this.orderFilter.pageSize = event.pageSize;
      this.orderFilter.pageNumber = event.pageIndex + Filter.one;
      this.getOrders();
    }

    filterOrder(name: string) {
      debugger;
      this.orderFilter.statusOrder = new Array<OrderStatusType>();
      this.orderFilter.statusOrder.push(OrderStatusType[name]);
      this.getOrders();
    }
   
  }


