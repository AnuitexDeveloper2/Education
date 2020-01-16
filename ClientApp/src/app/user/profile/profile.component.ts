import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialog } from '@angular/material';
import { FormControl } from "@angular/forms";
import { UserService } from "src/app/shared/services/user.service";
import { UserModelItem } from 'src/app/shared/models/user/UserModelItem';
import { BaseModel } from 'src/app/shared/models/Base/BaseModel';
import { ErrorComponent } from 'src/app/shared/components/error/error.component';


@Component({
  selector: 'app-edit-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
  providers: [UserService]
})
export class ProfileComponent  {
  
  userModelItem: UserModelItem;
  baseModel: BaseModel;
  firstName = new FormControl();
  lastName = new FormControl();

  constructor(@Inject(MAT_DIALOG_DATA) public data: UserModelItem, private userService: UserService, private dialog:MatDialog) {
   this.userModelItem = new UserModelItem();
   this.baseModel = new BaseModel();
   }

  
  editUser(){
    debugger;
    let user = new UserModelItem();
    user.firstName = this.firstName.value;
    user.lastName = this.lastName.value;
    user.id = this.data.id;
    this.userService.edit(user).subscribe(data => {
      this.baseModel.errors = data.errors
      this.checkError(this.baseModel.errors) 
    });
  }

  private checkError(errors:Array<string>) {
    debugger;
    if (errors.length > 0) {
      this.dialog.open(ErrorComponent,{data:this.baseModel.errors})
    }
  }
}
