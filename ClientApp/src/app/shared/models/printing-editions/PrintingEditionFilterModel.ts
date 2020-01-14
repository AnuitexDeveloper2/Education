import { BaseFilterModel } from "src/app/shared/models/Base/BaseFilterModel";
import { PrintingEditionSortType } from "src/app/shared/enums/PrintingEditionSortType";
import { ProductType } from '../../enums/ProductType';
import { CurrencyType } from '../../enums/CurrencyType';

export class PrintingEditionFilterModel extends BaseFilterModel
{
    printingEditionSortType: PrintingEditionSortType;
    typeProduct: Array<ProductType>;
    currencyType: CurrencyType;
    minPrice: number;
    maxPrice: number;
}