import { Component } from '@angular/core';
import { UserModelItem } from 'src/app/shared/models/user/UserModelItem';
import { LocalStorage } from 'src/app/shared/services/localStorage/localStorage';
import { AccountService } from 'src/app/shared/services/account/account.service';
import { MatDialog } from '@angular/material';
import { MyCartComponent } from 'src/app/cart/my-cart/my-cart.component';
import { OrderModelItem } from '../../models/order/OrderModelItem';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
  providers: [LocalStorage, AccountService]
})
export class HeaderComponent {
  user: UserModelItem;
  orderModelItem: OrderModelItem;
  constructor(private localStorage: LocalStorage, private accountService: AccountService, private dialog: MatDialog) {
    this.orderModelItem = new OrderModelItem();
    this.user = new UserModelItem();
    this.user = localStorage.getUser();
  }


  logOut() {
    localStorage.removeItem('user');
    localStorage.removeItem('cart');
    this.accountService.logOut(this.user).subscribe();
    location.href = 'http://localhost:4200/account/sign-in';
  }

  moveToCart() {
    debugger;
    let dialogRef = this.dialog.open(MyCartComponent,{data:this.orderModelItem}).afterClosed().subscribe();
  }

}
