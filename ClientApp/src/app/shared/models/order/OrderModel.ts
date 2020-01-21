import { OrderModelItem } from 'src/app/shared/models/order/OrderModelItem';
import { BaseModel } from 'src/app/shared/models/Base/BaseModel';

export class OrderModel extends BaseModel {
    itemsCount: number;
    items: Array<OrderModelItem>;
}