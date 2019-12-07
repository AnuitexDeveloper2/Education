import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegisterComponent } from './register/register.component';
import { ConfirmEmailComponent } from './confirm-email/confirm-email.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { SignOutComponent } from './sign-out/sign-out.component';



@NgModule({
  declarations: [RegisterComponent, ConfirmEmailComponent, SignInComponent, SignOutComponent],
  imports: [
    CommonModule
  ],
  exports:[
    RegisterComponent
  ]
})
export class AccountModule { }
