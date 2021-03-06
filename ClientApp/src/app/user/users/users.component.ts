import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { UserService } from 'src/app/shared/services/user/user.service';
import { UserModelItem } from 'src/app/shared/models/user/UserModelItem';
import { UserFilterModel } from 'src/app/shared/models/user/UserFilterModel';
import { MatSort, MatTableDataSource, MatDialog, PageEvent} from '@angular/material';
import { UserSortType } from 'src/app/shared/enums/UserSortType';
import { SortType } from 'src/app/shared/enums/SortType';
import { ProfileComponent } from 'src/app/user/profile/profile.component';
import { RemoveComponent } from 'src/app/shared/components/remove/remove.component';
import { UsersFilterType } from 'src/app/shared/enums/UsersFilterType';
import { ColumnName } from 'src/app/shared/constants/column-name';
import { Status } from 'src/app/shared/constants/status';
import { Filter } from 'src/app/shared/constants/Filter';
import { enumSelector } from 'src/app/Extention/EnumExtention';
import { Constants } from 'src/app/shared/constants/constants';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css'],
  providers: [UserService]
})

export class UsersComponent implements OnInit {

  userFilter: UserFilterModel;
  public dataSource = new MatTableDataSource();
  items: Array<UserModelItem>;
  count: number;
  displayedColumns: string[];
  userModelItem: UserModelItem;
  status = new FormControl();
  statusList: string[];
  pageIndex: number;
  currentStatus: UsersFilterType;

  constructor(private userService: UserService, public dialog: MatDialog ) {
    this.displayedColumns = [ ColumnName.Name, ColumnName.Email, ColumnName.Status, ColumnName.Edit],
    this.userFilter = new UserFilterModel,
    this.userModelItem = new UserModelItem(),
    this.statusList = enumSelector(Status);
    this.status = new FormControl();
  }

  ngOnInit() {
    this.userFilter.pageNumber = Filter.one;
    this.userFilter.pageSize = Filter.ten;
    this.getUsers();
  }

  getUsers() {
    this.userService.getUsers(this.userFilter).subscribe(data  => {
      this.count = data.count;
      this.items = data.items;
    });
  }

  changeUserStatus(id: number) {
    this.userService.changeUserStatus(id).subscribe();
  }

  sortUser(event: MatSort) {
    const element = event.active;
    this.userFilter.userSortType = UserSortType[event.active];
    this.userFilter.sortType = SortType[event.direction];
    this.getUsers();
  }

  edit(user: UserModelItem) {
    const dialogRef = this.dialog.open(ProfileComponent, {data: user}).afterClosed().subscribe(() => this.getUsers()); ;
  }

  remove(user: UserModelItem) {
   const dialogRef = this.dialog.open(RemoveComponent, {data: { name: user.firstName + Constants.Space + user.lastName }})
   .afterClosed().subscribe(data => {
     if (data) {
     this.userService.removeUser(user.id).subscribe(() => this.getUsers());
     }
   });
 }

  movePage(event: PageEvent) {
    this.userFilter.pageSize = event.pageSize;
    this.userFilter.pageNumber = event.pageIndex + Filter.one;
    this.getUsers();
  }

  applyFilter(filtervalue: string) {
    this.userFilter.searchString = filtervalue;
    this.userFilter.pageNumber = Filter.one;
    this.pageIndex = Filter.zero;
    this.getUsers();
  }

  filterUser(name: string) {
    this.userFilter.userFilterStatus = UsersFilterType[name];
    this.getUsers();
  }

}

