import { UserModelItem } from 'src/app/shared/models/user/UserModelItem';
import { OrderItemModelItem } from 'src/app/shared/models/orderItem/orderItemModelItem';

export class LocalStorage {

  items = new Array<OrderItemModelItem>();

  setUser(user: UserModelItem) {
     localStorage.setItem('user', JSON.stringify(user));
   }
    
  getUser(): UserModelItem {
     return JSON.parse(localStorage.getItem('user'));
   }
    
  setCart(orderItemModelItem: OrderItemModelItem) {
     let currentItems = this.getCart();
     if (currentItems != null) {
        this.items= currentItems;
      }
         this.items.push(orderItemModelItem);
      localStorage.setItem('cart', JSON.stringify(this.items));
      }

   removeItemFromCart(index: number) {
     let currentItems = this.getCart();
     currentItems.splice(index,1);
     localStorage.setItem('cart', JSON.stringify(currentItems))
   }
    
   getCart(): Array<OrderItemModelItem> {
      let currentCart: Array<OrderItemModelItem>;
      currentCart = JSON.parse(localStorage.getItem('cart'));
      if (currentCart === null) {
        return null;
      }
      return currentCart;
  }

  getTransactionId(): string {
    let id = localStorage.getItem('lsid')
    return id;
  }
}












   /* localCart.orderItemModel.items.forEach((element: OrderItemModelItem) => {
      cartModel.orderItemModel.items.push({
        count: parseInt(element.count.toString()),
        printingEditionId: parseInt(element.printingEditionId.toString()),
        //title: element.title.toString(),
        unitPrice: parseFloat(element.unitPrice.toString())
      });
    });

    return cartModel;
    */
 