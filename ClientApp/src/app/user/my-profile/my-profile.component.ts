import { Component} from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material';
import { Constants } from 'src/app/shared/constants/constants';
import { UserProfileEditModel } from 'src/app/shared/models/user/UserProfileEditModel';
import { LocalStorage } from 'src/app/shared/services/localStorage/localStorage';
import { UserService } from 'src/app/shared/services/user/user.service';
import { UserModelItem } from 'src/app/shared/models/user/UserModelItem';
import { BaseModel } from 'src/app/shared/models/Base/BaseModel';
import { ErrorComponent } from 'src/app/shared/components/error/error.component';
import { Filter } from 'src/app/shared/constants/Filter';

@Component({
  selector: 'app-my-profile',
  templateUrl: './my-profile.component.html',
  styleUrls: ['./my-profile.component.css'],
  providers: [LocalStorage,UserService]
})
export class MyProfileComponent {

  userForm: FormGroup;
  passwordForm: FormGroup;
  userModel: UserProfileEditModel;
  currentUser: UserModelItem;
  baseModel: BaseModel;
  hide: boolean;
  count: number
  constructor(private formBuilder: FormBuilder, private userService: UserService, private localStorage: LocalStorage, private dialog: MatDialog) {
    this.count = Filter.one;
    this.hide = false;
    this.baseModel = new BaseModel();
    this.userModel = new UserProfileEditModel();
    this.currentUser = this.localStorage.getUser();
    this.userForm = this.formBuilder.group({
      userName: [this.currentUser.userName, Validators.required],
      firstName: [this.currentUser.firstName, Validators.required],
      lastName: [this.currentUser.lastName, Validators.required],
      email: [this.currentUser.email, Validators.required]
    });
    this.passwordForm = this.formBuilder.group({
      password: [Constants.EmptyString, [Validators.required, Validators.minLength(8)]],
      newPassword: [Constants.EmptyString,[Validators.required, Validators.minLength(8)]]
    });
   }

   show() {
    if (this.count % 2 == 0) {
      this.hide = false;
    }
    if (this.count % 2 != 0) {
      this.hide = true;
    }
    this.count++;
   }

  

   editUser() {
     debugger;
     if (this.passwordForm.valid) {
      let oldPassword = this.passwordForm.get('password').value;
      let newPassword = this.passwordForm.get('newPassword').value;
      this.userService.changePassword(this.currentUser.id,oldPassword,newPassword).subscribe(data => {
        this.baseModel.errors = data.errors
        this.checkError(this.baseModel.errors) 
      });
     }

    this.userModel.firstName = this.userForm.get('firstName').value;
    this.userModel.lastName = this.userForm.get('lastName').value;
    this.userModel.email = this.userForm.get('email').value;
    this.userModel.id = this.currentUser.id;
    this.userService.edit(this.userModel).subscribe(data => {
      this.baseModel.errors = data.errors
      this.checkError(this.baseModel.errors) 
    })
   }
   private checkError(errors:Array<string>) {
    debugger;
    if (errors.length > 0) {
      this.dialog.open(ErrorComponent,{data:this.baseModel.errors})
    }
  }
}

