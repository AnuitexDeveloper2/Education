import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/services/user.service'
import { UserModelItem } from "src/app/shared/models/user/UserModelItem";
import { UserFilterModel } from 'src/app/shared/models/user/UserFilterModel';
import { MatSort, MatTableDataSource, MatDialog, PageEvent} from '@angular/material';
import { UserSortType } from 'src/app/shared/enums/UserSortType';
import { SortType } from 'src/app/shared/enums/SortType';
import { EditProfileComponent } from "src/app/user/edit-profile/edit-profile.component";
import { RemoveComponent } from 'src/app/user/remove/remove.component';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-get-users',
  templateUrl: './get-users.component.html',
  styleUrls: ['./get-users.component.css'],
  providers:[UserService]
})

export class GetUsersComponent implements OnInit {
  
  userFilter: UserFilterModel;
  public dataSource = new MatTableDataSource();
  items:  Array<UserModelItem>;
  count: number;
  displayedColumns: string[];
  userModelItem: UserModelItem;
  status = new FormControl();

  constructor(private userService:UserService,public dialog:MatDialog ) {
    this.displayedColumns= [ 'name', 'email','status','edit'],
    this.userFilter = new UserFilterModel,
    this.userModelItem = new UserModelItem()
  }
  
  ngOnInit() {
    this.userFilter.pageNumber = 1;
    this.userFilter.pageSize = 10;
    this.getUsers();
  }

  getUsers() {
    this.userService.getUsers(this.userFilter).subscribe(data  => {
      this.count = data.count;
      this.items = data.items;
    });
  }
  
  changeUserStatus(id:number){
    this.userService.changeUserStatus(id).subscribe();
  }

  sortUser(event:MatSort){
   
      if (event.active == 'name') {
        this.userFilter.userSortType = UserSortType.LastName;
      }
    
      if (event.active == 'email') {
        this.userFilter.userSortType = UserSortType.Email; 
       }

      if(event.direction == 'asc'){
        this.userFilter.sortType = SortType.Asc;
      }

      if(event.direction == 'desc'){
        this.userFilter.sortType = SortType.Desc;
      }
    this.getUsers();
  }

  edit(user:UserModelItem) {
   debugger;
    const dialogRef = this.dialog.open(EditProfileComponent, {data: user});
    this.getUsers();
  }

  remove(user:UserModelItem){
    debugger;
    const dialogRef = this.dialog.open(RemoveComponent, {data: user});
    this.getUsers();
  }

  pagination(event:PageEvent){
    this.userFilter.pageSize = event.pageSize;
    this.userFilter.pageNumber=event.pageIndex+1;
    this.getUsers()
  }

  applyFilter(filtervalue:string)
  {
    debugger;
    this.userFilter.searchString = filtervalue;
    const element = this.getUsers();
    
  }

}

