import { UserSortType } from "../../enums/UserSortType";
import { UsersFilterType } from "../../enums/UsersFilterType";
import { BaseFilterModel } from '../Base/BaseFilterModel';
import { SortType } from '../../enums/SortType';

export class UserFilterModel extends BaseFilterModel
{
    userSortType:UserSortType;
    userFilterStatus:UsersFilterType;
    sortType:SortType;
}