import { SortType } from '../../enums/SortType';

export class BaseFilterModel{
    searchString: string;
    pageNumber: number;
    pageSize: number;
    sortType : SortType;
}