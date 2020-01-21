import { OrderStatusType } from 'src/app/shared/enums/OrderStatusType';
import { OrderItemModel } from 'src/app/shared/models/orderItem/orderItemModel';
import { BaseModel } from 'src/app/shared/models/Base/BaseModel';

export class OrderModelItem extends BaseModel {

    id: number;
    date: string;
    description: string;
    userId: number;
    orderItems: OrderItemModel;
    status: OrderStatusType;
    transactionId: string;
    userName: string;
    userEmail: string;
    amountOrder: number;
    
}