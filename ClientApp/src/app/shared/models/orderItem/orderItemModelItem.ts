import { CurrencyType } from 'src/app/shared/enums/CurrencyType';
import { BaseModel } from 'src/app/shared/models/Base/BaseModel';

export class OrderItemModelItem extends BaseModel {

    amount: number;
    currency: CurrencyType;
    printingEditionId: number;
    printingEditionType: string;
    count: number;
    printingEditionName: string;
    printingEditionPrice: number;

}