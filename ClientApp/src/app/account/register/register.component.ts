import { Component, OnInit } from '@angular/core';
import { UserModelItem } from 'src/app/shared/models/user/UserModelItem';
import { AccountService } from '../../shared/services/account/account.service';
import { FormControl } from '@angular/forms'

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  providers:[AccountService]
})
export class RegisterComponent implements OnInit {
  UserName = new FormControl();
  firstName = new FormControl();
  lastName = new FormControl();
  email = new FormControl();
  password = new FormControl();

  constructor(private acc: AccountService) { }

  
  save(){
    let user = new UserModelItem();
    user.userName = this.UserName.value;
    user.firstName = this.firstName.value;
    user.lastName = this.lastName.value;
    user.email = this.email.value;
    debugger;
  this.acc.register(user,this.password.value).subscribe()
}
  ngOnInit() {
  }
}
