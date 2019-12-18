import { Component, OnInit } from '@angular/core';
import { AccountService } from "src/app/shared/services/account/account.service";
import { FormControl } from '@angular/forms';
import { AuthenticationService } from 'src/app/shared/services/AuthenticationService'
import { MatFormFieldModule } from "@angular/material/form-field";
import {MaterialModule} from "src/app/material/material.module"

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css'],
  providers: [AccountService],
})
export class SignInComponent  {
  
  constructor(private acc:AccountService) { }
  email=new FormControl('');
  password =new FormControl('');

  signIn(){
    debugger;
    this.acc.signIn(this.email.value,this.password.value).subscribe();
  }
  ngOnInit() {
  }

}
