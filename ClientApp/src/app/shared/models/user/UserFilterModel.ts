import { UserSortType } from "../../enums/UserSortType";
import { UsersFilterType } from "../../enums/UsersFilterType";
import { BaseFilterModel } from '../Base/BaseFilterModel';

export class UserFilterModel extends BaseFilterModel
{
    userSortType:UserSortType;
    filterType:UsersFilterType;
}