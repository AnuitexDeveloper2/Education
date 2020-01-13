import { BaseFilterModel } from "src/app/shared/models/Base/BaseFilterModel";
import { PrintingEditionSortType } from "src/app/shared/enums/PrintingEditionSortType";
import { ProductType } from '../../enums/ProductType';

export class PrintingEditionFilterModel extends BaseFilterModel
{
    printingEditionSortType: PrintingEditionSortType;
    TypeProduct: Array<ProductType>;
    minPrice: number;
    maxPrice: number;
}