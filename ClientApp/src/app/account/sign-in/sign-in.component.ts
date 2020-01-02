import { Component, OnInit } from '@angular/core';
import { AccountService } from "src/app/shared/services/account/account.service";
import { FormControl, Validators } from '@angular/forms';
import { BaseModel } from 'src/app/shared/models/Base/BaseModel';
import { MatDialog } from '@angular/material';
import { ErrorComponent } from "src/app/account/error/error.component";
import { Constants } from "src/app/shared/constants/constants";

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css'],
  providers: [AccountService],
})
export class SignInComponent  {
  baseModel:BaseModel;
  constructor(private accountService:AccountService,public dialog:MatDialog) {
    this.baseModel = new BaseModel()
  }
  email=new FormControl('',Validators.required);
  password =new FormControl('',Validators.required);

  signIn(){
    this.accountService.signIn(this.email.value,this.password.value).subscribe((data:BaseModel) => {
      this.baseModel.errors = data.errors
      if(this.baseModel.errors.length>0)
      {
       this.dialog.open(ErrorComponent,{data:this.baseModel.errors})
      }
  });
  }
}
