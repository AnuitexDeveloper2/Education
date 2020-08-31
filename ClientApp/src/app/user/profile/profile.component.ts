import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialog } from '@angular/material';
import { FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UserService } from 'src/app/shared/services/user/user.service';
import { UserModelItem } from 'src/app/shared/models/user/UserModelItem';
import { BaseModel } from 'src/app/shared/models/Base/BaseModel';
import { ErrorComponent } from 'src/app/shared/components/error/error.component';
import { UserProfileEditModel } from 'src/app/shared/models/user/UserProfileEditModel';


@Component({
  selector: 'app-edit-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
  providers: [UserService]
})
export class ProfileComponent {

  userModelItem: UserModelItem;
  baseModel: BaseModel;
  userForm: FormGroup;


  constructor(@Inject(MAT_DIALOG_DATA) public data: UserModelItem, private userService: UserService, private dialog: MatDialog, private formBuilder: FormBuilder) {

    this.userForm = this.formBuilder.group({
      firstName: [data.firstName, Validators.required],
      lastName: [data.lastName, Validators.required],
      email: [data.email, Validators.email]
    });
    this.userModelItem = new UserModelItem();
    this.baseModel = new BaseModel();
   }


  editUser() {
    const user = new UserProfileEditModel();
    user.firstName = this.userForm.get('firstName').value;
    user.lastName = this.userForm.get('lastName').value;
    user.email = this.userForm.get('email').value;
    user.id = this.data.id;
    this.userService.edit(user).subscribe(data => {
      this.baseModel.errors = data.errors;
      this.checkError(this.baseModel.errors);
    });
  }

  private checkError(errors: Array<string>) {
    if (errors.length > 0) {
      this.dialog.open(ErrorComponent, {data: this.baseModel.errors});
    }
  }
}
