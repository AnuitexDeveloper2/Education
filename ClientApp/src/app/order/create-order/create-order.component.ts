import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialog } from '@angular/material';
import { ColumnName } from 'src/app/shared/constants/column-name';
import { OrderItemModelItem } from 'src/app/shared/models/orderItem/orderItemModelItem';
import { OrderModelItem } from 'src/app/shared/models/order/OrderModelItem';
import { OrderService } from 'src/app/shared/services/order/order.service';
import { PaymentModel } from 'src/app/shared/models/payment/paymentModel';
import { ErrorComponent } from 'src/app/shared/components/error/error.component';
import { LocalStorage } from 'src/app/shared/services/localStorage/localStorage';

@Component({
  selector: 'app-create-order',
  templateUrl: './create-order.component.html',
  styleUrls: ['./create-order.component.css']
})

export class CreateOrderComponent {

  
  displayedColumns: string[]; 
  dataSource: Array<OrderItemModelItem>;
  orderModelItem: OrderModelItem;
  
  constructor(@Inject(MAT_DIALOG_DATA) public data: OrderItemModelItem, private service: OrderService, private dialog: MatDialog, private localStorage: LocalStorage) { 
    debugger;
    this.dataSource = new Array<OrderItemModelItem>();
    this.dataSource.push(data);
    this.orderModelItem = new OrderModelItem();
    this.displayedColumns = [ColumnName.Product, ColumnName.UnitPrice, ColumnName.Qty, ColumnName.OrderAmount];
}

  create() {
    debugger;
    this.orderModelItem.orderItems.items.push(this.data)
    this.service.createOrder(this.orderModelItem).subscribe((data: PaymentModel) => {
     this.checkError(data);
    })
  }

  checkError(data:PaymentModel) {
    if (data.errors.length > 0) {
      this.dialog.open(ErrorComponent,{ data: data.errors });
    }
    if (data.errors.length == 0) {
      this.localStorage.setPayment(data.id);
    }
  }

}
  