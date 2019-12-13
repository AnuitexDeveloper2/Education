import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AccountRoutingModule } from './account-routing.module';

import { RegisterComponent } from './register/register.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { SignOutComponent } from './sign-out/sign-out.component';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { ConfirmEmailComponent } from './confirm-email/confirm-email.component';


@NgModule({
  declarations: [RegisterComponent, SignInComponent, SignOutComponent, ConfirmEmailComponent],
  imports: [
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    AccountRoutingModule  ]
})
export class AccountModule { }
