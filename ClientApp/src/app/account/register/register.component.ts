import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material';
import { UserModelItem } from 'src/app/shared/models/user/UserModelItem';
import { AccountService } from 'src/app/shared/services/account/account.service';
import { BaseModel } from 'src/app/shared/models/Base/BaseModel';
import { ErrorComponent } from 'src/app/shared/components/error/error.component';
import { Constants } from 'src/app/shared/constants/constants';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  providers:[AccountService]
})

export class RegisterComponent {
  user: UserModelItem;
  baseModel: BaseModel;
  userForm: FormGroup;
  constructor(private accountService: AccountService,public dialog:MatDialog,private formBuilder:FormBuilder) {
    this.user = new UserModelItem();
    this.baseModel = new BaseModel();
    this.userForm = this.formBuilder.group(
      {
        userName: [Constants.EmptyString,Validators.required],
        firstName: [Constants.EmptyString,Validators.required],
        lastName: [Constants.EmptyString,Validators.required],
        email: [Constants.EmptyString,Validators.email],
        password: [Constants.EmptyString,Validators.pattern('^[0-9]+$')]
      }
    )
   }

  save() {
  this.accountService.register(this.userForm.value).subscribe(data => {
    debugger;
      this.baseModel.errors = data.errors
      if(this.baseModel.errors.length>0){
       this.dialog.open(ErrorComponent,{data:this.baseModel.errors})
      }
  })
     this.err(this.baseModel.errors);
 }
  private err(errors:Array<string>) {

  }
}
