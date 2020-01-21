import { SortType } from 'src/app/shared/enums/SortType';
import { CurrencyType } from 'src/app/shared/enums/CurrencyType';

export class BaseFilterModel {
    
    searchString: string;
    pageNumber: number;
    pageSize: number;
    sortType: SortType;
    currencyType: CurrencyType;
   
}