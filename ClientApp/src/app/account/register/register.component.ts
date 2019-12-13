import { Component, OnInit } from '@angular/core';
import { UserModel } from 'src/app/shared/models/user/UserModel';
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
    let user = new UserModel();
    user.UserName = this.UserName.value;
    user.firstName = this.firstName.value;
    user.lastName = this.lastName.value;
    user.email = this.email.value;
    debugger;
  this.acc.register(user,this.password.value).subscribe()
}
  ngOnInit() {
  }
}
