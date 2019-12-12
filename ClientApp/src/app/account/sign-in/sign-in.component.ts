import { Component, OnInit } from '@angular/core';
import { AccountService } from "../../shared/services/account/account.service";
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css'],
  providers: [AccountService]
})
export class SignInComponent  {
  email=new FormControl('');
  password =new FormControl('');

  constructor(private acc:AccountService) { }

  signIn(){
    debugger;
    this.acc.signIn(this.email.value,this.password.value).subscribe
  }
  ngOnInit() {
  }

}
