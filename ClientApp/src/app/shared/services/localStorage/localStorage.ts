import { UserModelItem } from 'src/app/shared/models/user/UserModelItem';
import { OrderItemModel } from 'src/app/shared/models/orderItem/orderItemModel';
import { OrderItemModelItem } from 'src/app/shared/models/orderItem/orderItemModelItem';
import { CartModel } from 'src/app/shared//models/Cart/cartModel';
import { OrderModelItem } from '../../models/order/OrderModelItem';

export class LocalStorage {
    setUser(user: UserModelItem): void {
        localStorage.setItem('user', JSON.stringify(user));
      }
    
      getUser(): UserModelItem {
        return JSON.parse(localStorage.getItem('user'));
      }
    
      setCart(orderModelItem: OrderModelItem): void {
        localStorage.setItem('cart', JSON.stringify(orderModelItem));
      }
    
      getCart(): CartModel {
    
        let localCart: CartModel;
        localCart = JSON.parse(localStorage.getItem('cart'));
        if (localCart === null) {
          return null;
        }
         let cartModel: CartModel = new CartModel();
    cartModel.orderItemModel = new OrderModelItem();
    cartModel.orderItemModel.orderItems.items = new Array<OrderItemModelItem>();

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
  }
       

}