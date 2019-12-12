import { Component, OnInit } from '@angular/core';
import { UserModel } from 'src/app/shared/models/UserModel';
import { AccountService } from '../../shared/services/account/account.service';
import { FormControl } from '@angular/forms'

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  providers:[AccountService]
})
export class RegisterComponent implements OnInit {
  firstName = new FormControl('');
  lastName = new FormControl('');
  email = new FormControl('');
  password = new FormControl('');

  constructor(private acc: AccountService) { }

  
  save(){
    let user = new UserModel();
    user.firstName = this.firstName.value;
    user.lastName = this.lastName.value;
    user.email = this.email.value;
    user.password = this.password.value;
  debugger;   
  this.acc.register(user).subscribe()
}
  ngOnInit() {
  }
}
