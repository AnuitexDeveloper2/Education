import { OrderStatusType } from 'src/app/shared/enums/OrderStatusType';
import { SortOrderType } from 'src/app/shared/enums/SortOrderType';
import { BaseFilterModel } from 'src/app/shared/models/Base/BaseFilterModel';

export class OrderFilterModel extends BaseFilterModel {
    id:number;
    statusOrder: Array<OrderStatusType>;
    sortOrder: SortOrderType;

}