import { Component } from '@angular/core';
import { FormControl, FormGroupDirective, NgForm, Validators, FormGroup, FormBuilder } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
import { Constants } from 'src/app/shared/constants/constants';
import { AccountService } from 'src/app/shared/services/account/account.service';


@Component({
  selector: 'app-sign-out',
  templateUrl: './sign-out.component.html',
  styleUrls: ['./sign-out.component.css'],
  providers: [AccountService]
})
export class SignOutComponent  {
   
  userForm: FormGroup
  constructor(private formBuilder: FormBuilder,public accountService:AccountService) {
    this.userForm = this.formBuilder.group(
      {
        userName: [Constants.emptyString,Validators.required],
        firstName: [Constants.emptyString,Validators.required],
        lastName: [Constants.emptyString,Validators.required],
        email: [Constants.emptyString,Validators.required],
        password:[Constants.emptyString,Validators.required]
      }
    )
  }

  save(){
    this.accountService.register(this.userForm.value).subscribe();
  }


}
