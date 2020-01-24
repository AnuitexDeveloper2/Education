import { Component } from '@angular/core';
import { MatDialog } from '@angular/material';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { AccountService } from "src/app/shared/services/account/account.service";
import { ErrorComponent } from "src/app/shared/components/error/error.component";
import { Constants } from "src/app/shared/constants/constants";
import { LocalStorage } from 'src/app/shared/services/localStorage/localStorage';
import { UserModelItem } from 'src/app/shared/models/user/UserModelItem';



@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css'],
  providers: [AccountService,LocalStorage],
})
export class SignInComponent {
  
  userModel: UserModelItem;
  loginForm: FormGroup;
  email: string;
  password: string;
  

  constructor(private accountService:AccountService,private dialog:MatDialog, private localStorage: LocalStorage, private formBuilder: FormBuilder ) {

    this.userModel = new UserModelItem();
    this.loginForm = this.formBuilder.group({
      email: [Constants.EmptyString,[Validators.required, Validators.email]],
      password: [Constants.EmptyString, [Validators.required, Validators.minLength(8)]]
    });
  }

  signIn() {
    this.email = this.loginForm.get('email').value;
    this.password = this.loginForm.get('password').value;
    this.accountService.signIn(this.email,this.password).subscribe((data: UserModelItem) => {
      this.checkErrors(data);
    });
  }

  checkErrors(user: UserModelItem) {
    if(user.errors.length>0) {
      this.dialog.open(ErrorComponent,{data:user.errors})
    }
    if(user.errors.length === 0)
    {
      this.localStorage.setUser(user)
      location.href = 'http://localhost:4200/books/main';
    }
  }
}
