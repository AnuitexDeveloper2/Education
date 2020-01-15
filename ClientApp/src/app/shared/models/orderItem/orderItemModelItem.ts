import { CurrencyType } from '../../enums/CurrencyType';

export class OrderItemModelItem {
    amount: number;
    currency: CurrencyType;
    printingEditionId: number;
    printingEditionType: string;
    count: number;
    printingEditionName: string;
}