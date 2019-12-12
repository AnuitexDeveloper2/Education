import { Component, OnInit } from '@angular/core';
import { UserModel } from 'src/app/shared/models/UserModel';
import { AccountService } from "../../shared/services/account/account.service";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  providers:[AccountService]
})
export class RegisterComponent implements OnInit {
  user: UserModel = new UserModel();
  password:string;

  constructor(private acc: AccountService) { }
save(){
  debugger;   
  this.acc.register(this.user).subscribe
}
  ngOnInit() {
  }
}
