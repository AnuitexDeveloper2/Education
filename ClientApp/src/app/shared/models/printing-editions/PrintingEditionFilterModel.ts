import { BaseFilterModel } from "src/app/shared/models/Base/BaseFilterModel";
import { PrintingEditionSortType } from "src/app/shared/enums/PrintingEditionSortType";
import { ProductType } from 'src/app/shared/enums/ProductType';
import { CurrencyType } from 'src/app/shared/enums/CurrencyType';

export class PrintingEditionFilterModel extends BaseFilterModel {

    printingEditionSortType: PrintingEditionSortType;
    typeProduct: Array<ProductType>;
    currencyType: CurrencyType;
    minPrice: number;
    maxPrice: number;

}