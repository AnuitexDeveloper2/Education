import { Component, OnInit } from '@angular/core';
import { UserModelItem } from 'src/app/shared/models/user/UserModelItem';
import { AccountService } from 'src/app/shared/services/account/account.service';
import {FormControl} from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  providers:[AccountService]
})
export class RegisterComponent {
  user: UserModelItem;
  constructor(private acc: AccountService) {
    this.user = new UserModelItem();
   }

   
  save(){
    debugger;
  this.acc.register(this.user).subscribe()
 }
}
