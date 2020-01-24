import { Component } from '@angular/core';
import { UserModelItem } from 'src/app/shared/models/user/UserModelItem';
import { LocalStorage } from 'src/app/shared/services/localStorage/localStorage';
import { AccountService } from 'src/app/shared/services/account/account.service';
import { MatDialog } from '@angular/material';
import { MyCartComponent } from 'src/app/cart/my-cart/my-cart.component';
import { OrderModelItem } from 'src/app/shared/models/order/OrderModelItem';
import { OrderItemModel } from 'src/app/shared/models/orderItem/orderItemModel';
import { OrderItemModelItem } from 'src/app/shared/models/orderItem/orderItemModelItem';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
  providers: [LocalStorage, AccountService]
})
export class HeaderComponent {
  user: UserModelItem;
  orderModelItem: OrderModelItem;
  countItems: number;
  constructor(private localStorage: LocalStorage, private accountService: AccountService, private dialog: MatDialog) {
    this.orderModelItem = new OrderModelItem();
    this.orderModelItem.orderItems = new OrderItemModel();
    this.orderModelItem.orderItems.items = new Array<OrderItemModelItem>();
    this.orderModelItem.orderItems.items = this.localStorage.getCart();
    this.countItems = this.countingItems(this.orderModelItem.orderItems.items)
    this.user = new UserModelItem();
    this.user = this.definitionUser();
  }


  logOut() {
    
    localStorage.removeItem('cart');
    localStorage.removeItem('user');
    this.accountService.logOut(this.user).subscribe();
    location.href = 'http://localhost:4200/account/sign-in';
  }

  moveToCart() {
    if (this.countItems > 0) {
      let dialogRef = this.dialog.open(MyCartComponent,{data:this.orderModelItem}).afterClosed().subscribe();
    }
  }

   private countingItems(items: Array<OrderItemModelItem>) : number {
      if (items == null) {
        return 0;
      }
      return items.length;
    }

    private definitionUser(): UserModelItem {
      let user = this.localStorage.getUser();
      if (user == null) {
        user = new UserModelItem();
        user.role = 'user'
      }
      return user;
    }

}
