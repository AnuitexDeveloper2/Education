import { SortType } from '../../enums/SortType';
import { CurrencyType } from '../../enums/CurrencyType';

export class BaseFilterModel{
    searchString: string;
    pageNumber: number;
    pageSize: number;
    sortType: SortType;
    currencyType: CurrencyType;
   
}