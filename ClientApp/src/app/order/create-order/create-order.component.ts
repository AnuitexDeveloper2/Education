import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';
import { ColumnName } from 'src/app/shared/constants/column-name';
import { OrderItemModelItem } from 'src/app/shared/models/orderItem/orderItemModelItem';
import { OrderModelItem } from 'src/app/shared/models/order/OrderModelItem';
import { OrderService } from 'src/app/shared/services/order/order.service';

@Component({
  selector: 'app-create-order',
  templateUrl: './create-order.component.html',
  styleUrls: ['./create-order.component.css']
})

export class CreateOrderComponent implements OnInit {

  
  displayedColumns: string[]; 
  dataSource: Array<OrderItemModelItem>;
  orderModelItem: OrderModelItem;
  localStorage: Storage;
  
  constructor(@Inject(MAT_DIALOG_DATA) public data: OrderItemModelItem, private service: OrderService) { 
    debugger;
    this.dataSource = new Array<OrderItemModelItem>();
    this.dataSource.push(data);
    this.orderModelItem = new OrderModelItem();
    this.displayedColumns = [ColumnName.Product, ColumnName.UnitPrice, ColumnName.Qty, ColumnName.OrderAmount];
    //this.orderModelItem.orderItems.items.push(data);
}
  ngOnInit() {

  }

  create() {
    debugger;
    this.orderModelItem.orderItems.items.push(this.data)
    this.service.createOrder(this.orderModelItem).subscribe()
  }

}
  