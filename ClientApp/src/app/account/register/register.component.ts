import { Component, OnInit } from '@angular/core';
import { UserModelItem } from 'src/app/shared/models/user/UserModelItem';
import { AccountService } from 'src/app/shared/services/account/account.service';
import {FormControl, FormGroupDirective, NgForm, Validators} from '@angular/forms';
import {ErrorStateMatcher} from '@angular/material/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  providers:[AccountService]
})
export class RegisterComponent implements OnInit {
  userName = new FormControl();
  firstName = new FormControl();
  lastName = new FormControl();
  email = new FormControl();
  password = new FormControl();

  constructor(private acc: AccountService) { }

  
  save(){
    let user = new UserModelItem();
    user.userName = this.userName.value;
    user.firstName = this.firstName.value;
    user.lastName = this.lastName.value;
    user.email = this.email.value;
    debugger;
  this.acc.register(user,this.password.value).subscribe()
}
  ngOnInit() {
  }
}
