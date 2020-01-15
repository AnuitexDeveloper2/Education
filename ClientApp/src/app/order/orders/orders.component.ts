import { Component, OnInit } from '@angular/core';
import { OrderService } from 'src/app/shared/services/order/order.service';
import { OrderFilterModel } from 'src/app/shared/models/order/OrderFilterModel';
import { OrderModelItem } from 'src/app/shared/models/order/OrderModelItem';
import { Filter } from 'src/app/shared/constants/Filter';
import { ColumnName } from 'src/app/shared/constants/column-name';





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
  
  constructor(private service: OrderService) {
    this.orderFilter = new OrderFilterModel();
    this.displayedColumns = [ColumnName.Order,ColumnName.Date,ColumnName.UserName,ColumnName.UserEmail,ColumnName.Product,ColumnName.Title,ColumnName.Qty,ColumnName.OrderAmount,ColumnName.Status]
   }

  ngOnInit() {
    this.orderFilter.statusOrder = [Filter.zero,Filter.one];
    this.orderFilter.pageNumber = Filter.one;
    this.orderFilter.pageSize = Filter.ten;
    this.getOrders();
  }
  getOrders() {
    this.service.getOrders(this.orderFilter).subscribe(data => {
      this.itemsCount = data.itemsCount;
      this.items = data.items;
    });
  }

}
