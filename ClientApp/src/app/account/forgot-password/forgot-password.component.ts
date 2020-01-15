import { Component, OnInit } from '@angular/core';
import { AccountService } from "src/app/shared/services/account/account.service";
import { FormControl } from "@angular/forms";
import { BaseModel } from 'src/app/shared/models/Base/BaseModel';
import { Constants } from 'src/app/shared/constants/constants';
import { MatDialog } from '@angular/material';
import { ErrorComponent } from "src/app/shared/error/error.component";


@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.css'],
  providers:[AccountService]
})
export class ForgotPasswordComponent {

  baseModel: BaseModel;
  constructor(private userService: AccountService, public dialog:MatDialog) {
    this.baseModel = new BaseModel();
   }
  
  email = new FormControl(Constants.emptyString);   

   forgot(){
   this.userService.forgotPassword(this.email.value).subscribe(data =>{
    this.baseModel.errors = data.errors
    if(this.baseModel.errors.length>0){
     this.dialog.open(ErrorComponent,{data:this.baseModel.errors})
    }
   })
 }


}
