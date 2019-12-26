import { Component, OnInit } from '@angular/core';
import { UserModelItem } from 'src/app/shared/models/user/UserModelItem';
import { AccountService } from 'src/app/shared/services/account/account.service';
import {FormControl, Validators, FormGroup} from '@angular/forms';
import {ErrorStateMatcher} from '@angular/material/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  providers:[AccountService]
})
export class RegisterComponent {
  user: UserModelItem;
  password: FormControl;
  confirmPassword: FormControl;
  constructor(private acc: AccountService) {
    this.user = new UserModelItem();
    this.confirmPassword = new FormControl();
    this.password = new FormControl();
   }

   
  save(){
    debugger;
  this.acc.register(this.user).subscribe()
}

  
 
}
