import { UserModelItem } from 'src/app/shared/models/user/UserModelItem';
import { OrderItemModel } from 'src/app/shared/models/orderItem/orderItemModel';
import { OrderItemModelItem } from 'src/app/shared/models/orderItem/orderItemModelItem';
import { CartModel } from 'src/app/shared//models/Cart/cartModel';
import { OrderModelItem } from '../../models/order/OrderModelItem';

export class LocalStorage {

      items = new Array<OrderItemModelItem>();
      constructor() {
        
      }
    setUser(user: UserModelItem): void {
        localStorage.setItem('user', JSON.stringify(user));
      }
    
      getUser(): UserModelItem {
        return JSON.parse(localStorage.getItem('user'));
      }
    
      setCart(orderItemModelItem: OrderItemModelItem): void {
        let test = this.getCart();
        if (test != null) {
          this.items= test;
        }
        this.items.push(orderItemModelItem);
       
        localStorage.setItem('cart', JSON.stringify(this.items));
      }
    
      getCart(): Array<OrderItemModelItem> {
    
        let currentCart: Array<OrderItemModelItem>;
        currentCart = JSON.parse(localStorage.getItem('cart'));
        if (currentCart === null)
        {
          return null;
        }
        return currentCart;
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
 