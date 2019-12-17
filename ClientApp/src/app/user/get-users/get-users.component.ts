import { Component, OnInit } from '@angular/core';
import { UserService } from '../../shared/services/user.service'
import { UserModelItem } from "../../shared/models/user/UserModelItem";
import { UserFilterModel } from 'src/app/shared/models/user/UserFilterModel';
import { UserModel } from 'src/app/shared/models/user/UserModel';
import {MatPaginator, MatSort, MatTableDataSource, MatDialog} from '@angular/material';
import { UserSortType } from 'src/app/shared/enums/UserSortType';
import { SortType } from 'src/app/shared/enums/SortType';

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
  displayedColumns: string[] ;

  constructor(private userService:UserService,public dialog:MatDialog ) {
    this.displayedColumns= [ 'name', 'email','status','edit'],
    this.userFilter = new UserFilterModel
  }
  
  ngOnInit() {
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
}

