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
import { UsersFilterType } from 'src/app/shared/enums/UsersFilterType';


@Component({
  selector: 'app-get-profile',
  templateUrl: './get-profile.component.html',
  styleUrls: ['./get-profile.component.css']
})
export class GetProfileComponent  {

  constructor() { }

  toppings = new FormControl();

  toppingList: string[] = ['Extra cheese', 'Mushroom', 'Onion', 'Pepperoni', 'Sausage', 'Tomato'];

  save(name:string){
    debugger;
    name = this.toppings.value;
  }

}
