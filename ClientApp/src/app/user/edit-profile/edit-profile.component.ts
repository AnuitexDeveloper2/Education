import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';
import { FormControl } from "@angular/forms";
import { UserService } from "src/app/shared/services/user.service";
import { UserModelItem } from 'src/app/shared/models/user/UserModelItem';


@Component({
  selector: 'app-edit-profile',
  templateUrl: './edit-profile.component.html',
  styleUrls: ['./edit-profile.component.css'],
  providers: [UserService]
})
export class EditProfileComponent  {
  
  userModelItem: UserModelItem;
  firstName = new FormControl();
  lastName = new FormControl();

  constructor(@Inject(MAT_DIALOG_DATA) public data: UserModelItem, private userService: UserService) {
   this.userModelItem = new UserModelItem();
   }

  
  editUser(){
    debugger;
    let user = new UserModelItem();
    user.firstName = this.firstName.value;
    user.lastName = this.lastName.value;
    user.id = this.data.id;
    this.userService.edit(user).subscribe();
  }

}
